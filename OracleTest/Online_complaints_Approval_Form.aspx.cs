using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Online_complaints_Approval_Form
{
	public partial class Online_complaints_Approval_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			btnSubmit.Attributes.Add("OnClick", "JavaScript:validate();");

			if (!(IsPostBack))
			{
				if ((Convert.ToString(Request.Params["CASE_NO"]) != null) & (Convert.ToString(Request.Params["BK_NO"]) != null) & (Convert.ToString(Request.Params["SET_NO"]) != null) & (Convert.ToString(Request.Params["TEMP_COMPLAINT_ID"]) != null))
				{
					lblCaseNo.Text = Convert.ToString(Request.Params["CASE_NO"].Trim());
					txtBKNo.Text = Convert.ToString(Request.Params["BK_NO"].Trim());
					txtSetNo.Text = Convert.ToString(Request.Params["SET_NO"].Trim());
					lblTempCompID.Text = Convert.ToString(Request.Params["TEMP_COMPLAINT_ID"].Trim());
					show();
					Panel3.Visible = false;
					Panel2.Visible = true;

				}
				else
				{
					fillgrid();
					Panel3.Visible = true;
					Panel2.Visible = false;
				}

				//				Panel_1.Visible=false;
				//				Panel_2.Visible=false;
			}
		}

		void show()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string str3 = "select P.CASE_NO, P.PO_NO,to_char(P.PO_DT,'dd/mm/yyyy') PO_DT,V.VENDOR,T20.BK_NO, T09.IE_NAME,T20.SET_NO, T20.IC_NO,to_char(T20.IC_DT,'dd/mm/yyyy') IC_DATE,V06.CONSIGNEE,T.TEMP_COMPLAINT_ID,to_char(T.TEMP_COMPLAINT_DT,'dd/mm/yyyy') TEMP_COMPLAINT_DATE,T.ITEM_DESC, T.QTY_OFFERED,T.QTY_REJECTED, T.REJECTION_VALUE,T.REJECTION_REASON, T.TEMP_COMPLAINT_ID  from V05_VENDOR V,T13_PO_MASTER P,T20_IC T20,TEMP_ONLINE_COMPLAINTS T, V06_CONSIGNEE V06,T09_IE T09 where T.CASE_NO=P.CASE_NO and P.VEND_CD=V.VEND_CD and T20.CONSIGNEE_CD=V06.CONSIGNEE_CD AND T.BK_NO=T20.BK_NO and T.SET_NO=T20.SET_NO and T.CASE_NO=T20.CASE_NO AND T20.IE_CD=T09.IE_CD and T.CASE_NO= '" + lblCaseNo.Text + "' and T.BK_NO='" + txtBKNo.Text + "' and T.SET_NO='" + txtSetNo.Text + "' and TEMP_COMPLAINT_ID='" + lblTempCompID.Text.Trim() + "' ";

				OracleCommand myOracleCommand3 = new OracleCommand(str3, conn1);
				conn1.Open();
				OracleDataReader reader = myOracleCommand3.ExecuteReader();
				while (reader.Read())
				{
					lblTempCompID.Text = reader["TEMP_COMPLAINT_ID"].ToString();
					lblTempCompDt.Text = reader["TEMP_COMPLAINT_DATE"].ToString();
					lblPONO.Text = reader["PO_NO"].ToString();
					lblPODT.Text = reader["PO_DT"].ToString();
					lblVend.Text = reader["VENDOR"].ToString();
					lblICNO.Text = reader["IC_NO"].ToString();
					lblICDT.Text = reader["IC_DATE"].ToString();
					txtBKNo.Text = reader["BK_NO"].ToString();
					txtSetNo.Text = reader["SET_NO"].ToString();
					lblConsignee.Text = reader["CONSIGNEE"].ToString();
					lblIE.Text = reader["IE_NAME"].ToString();
					lblQTYOFF.Text = reader["QTY_OFFERED"].ToString();
					lblQTYREJ.Text = reader["QTY_REJECTED"].ToString();
					lblREJValue.Text = reader["REJECTION_VALUE"].ToString();
					lblRejReason.Text = reader["REJECTION_REASON"].ToString();
					lblITEM.Text = reader["ITEM_DESC"].ToString();
					lblCaseNo.Text = reader["CASE_NO"].ToString();
					HyperLink1.NavigateUrl = "/RBS/Online_Complaints/" + reader["TEMP_COMPLAINT_ID"].ToString() + ".pdf";

				}
				reader.Close();
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
		void fillgrid()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			try
			{
				string str1 = "select t.CASE_NO,TEMP_COMPLAINT_ID,to_char(TEMP_COMPLAINT_DT,'dd/mm/yyyy') COMPLAINT_DATE,t.CONSIGNEE_NAME,t.CONSIGNEE_DESIG,t.CONSIGNEE_EMAIL,t.CONSIGNEE_MOBILE,t.BK_NO,t.SET_NO,t.INSP_REGION,t.REJ_MEMO_NO,to_char(t.REJ_MEMO_DT,'dd/mm/yyyy')REJ_MEMO_DATE,t.REJECTION_VALUE,t.REJECTION_REASON,t.REMARKS,'Online_Complaints/'||t.TEMP_COMPLAINT_ID||'.pdf' COMP_DOC from TEMP_ONLINE_COMPLAINTS t where  t.INSP_REGION='" + Session["Region"].ToString() + "' and t.STATUS is null ";


				string str2 = str1 + " ORDER BY t.TEMP_COMPLAINT_DT,t.TEMP_COMPLAINT_ID";

				OracleDataAdapter da1 = new OracleDataAdapter(str2, conn1);
				DataSet dsP1 = new DataSet();
				OracleCommand myOracleCommand1 = new OracleCommand(str2, conn1);
				conn1.Open();
				da1.SelectCommand = myOracleCommand1;
				da1.Fill(dsP1, "Table");
				//OracleDataAdapter da1 = new OracleDataAdapter(str1, conn1); 
				if (dsP1.Tables[0].Rows.Count == 0)
				{
					grdCNO.Visible = false;
					//repdiv.Visible=false;
					//Label6.Visible =true;
					//						throw new System.Exception("No PurchaseOrder found. !!! ");
					lblError.Visible = true;
					grdCNO.Visible = false;

				}
				else
				{
					grdCNO.DataSource = dsP1;
					grdCNO.DataBind();
					grdCNO.Visible = true;
					lblError.Visible = false;
					//repdiv.Visible=true;
					//Label6.Visible =false;
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

		protected void lstJIRequired_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lstJIRequired.SelectedValue == "N")
			{
				Label9.Visible = true;
				lslNOJIReasons.Visible = true;
				Label14.Visible = false;
				lstJiRegion.Visible = false;
				Label32.Visible = false;
				lstJIIE.Visible = false;
				Label29.Visible = false;
				txtJIFixDT.Visible = false;
				lblJiSrNo.Visible = false;
				lblJiSno.Visible = false;


			}
			else if (lstJIRequired.SelectedValue == "Y")
			{
				Label9.Visible = false;
				lslNOJIReasons.Visible = false;
				Label14.Visible = true;
				lstJiRegion.Visible = true;
				Label32.Visible = true;
				lstJIIE.Visible = true;
				Label29.Visible = true;
				txtJIFixDT.Visible = true;
				lblJiSrNo.Visible = false;
				lblJiSno.Visible = false;


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
				lblJiSrNo.Visible = true;
				lblJiSno.Visible = true;

			}
		}

		protected void btnReject_Click(object sender, System.EventArgs e)
		{
			btnSave.Visible = false;
			Label8.Visible = true;
			txtRejReason.Visible = true;
			btnSaveReject.Visible = true;
			Label9.Visible = false;
			lslNOJIReasons.Visible = false;
			Label14.Visible = false;
			lstJiRegion.Visible = false;
			Label21.Visible = false;
			lstJiRegion.Visible = false;
			lstJIRequired.Visible = false;
			Label19.Visible = false;
			lblComplaintId.Visible = false;
			Label20.Visible = false;
			lblComplaintDt.Visible = false;
			Label32.Visible = false;
			lstJIIE.Visible = false;
			Label29.Visible = false;
			txtJIFixDT.Visible = false;
			//
			//			Panel_1.Visible=true;
			//			Panel_2.Visible=false;
		}

		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			OracleCommand Cmd = new OracleCommand("select to_char(sysdate,'dd/mm/yyyy') from dual", conn1);
			string wDate = Convert.ToString(Cmd.ExecuteScalar());
			conn1.Close();
			string MySql1 = "";
			//			string MyMsg="";
			//
			try
			{
				//conn1= new System.Data.OracleClient.OracleConnection((ConfigurationSettings.AppSettings["ConnectionString"])) ;

				if (lstJIRequired.SelectedValue != "N")
				{


					//								conn1.Open(); 
					//								OracleCommand MyCmd = new OracleCommand("select to_char(sysdate,'dd/mm/yyyy') from dual",conn1);
					//								string wDate=Convert.ToString(MyCmd.ExecuteScalar());
					//								conn1.Close();

					if ((lstJIRequired.SelectedValue == "Y") & (lstJiRegion.SelectedValue != "") & (lblJiSno.Text.Trim() == ""))
					{
						lblJIDt.Text = wDate;
						lblJiSno.Text = generate_ji_sno();
						lblJiSno.Visible = true;

						btnSave.Enabled = false;
						lstJIRequired.Enabled = false;
						lstJiRegion.Enabled = false;

						//						if(Convert.ToInt16(lblJIDt.Text.Substring(6,4))>=2013)
						//						{
						//							send_IE_Email();
						//						}

						if (lstJiRegion.SelectedValue == Session["Region"].ToString())
						{

							MySql1 = "Update T40_CONSIGNEE_COMPLAINTS " +
								"Set JI_REQUIRED='" + lstJIRequired.SelectedValue + "',JI_REGION='" + lstJiRegion.SelectedValue + "',JI_SNO='" + lblJiSno.Text + "',JI_IE_CD='" + lstJIIE.SelectedValue + "',JI_DT=to_date('" + lblJIDt.Text + "','dd/mm/yyyy'),JI_FIX_DT=to_date('" + txtJIFixDT.Text + "','dd/mm/yyyy'),JI_STATUS_CD=0,USER_ID='" + Session["Uname"] + "',DATETIME=to_date('" + wDate + "','dd/mm/yyyy-HH24:MI:SS') " +
								"Where COMPLAINT_ID='" + lblComplaintId.Text + "'";
						}
						else
						{
							MySql1 = "Update T40_CONSIGNEE_COMPLAINTS " +
								"Set JI_REQUIRED='" + lstJIRequired.SelectedValue + "',JI_REGION='" + lstJiRegion.SelectedValue + "',JI_SNO='" + lblJiSno.Text + "',JI_DT=to_date('" + lblJIDt.Text + "','dd/mm/yyyy'),JI_STATUS_CD=0,USER_ID='" + Session["Uname"] + "',DATETIME=to_date('" + wDate + "','dd/mm/yyyy-HH24:MI:SS') " +
								"Where COMPLAINT_ID='" + lblComplaintId.Text + "'";
						}
					}




					lblJiSrNo.Visible = true;
					lblJiSno.Visible = true;



				}
				else if (lstJIRequired.SelectedValue == "N")
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

					MySql1 = "Update T40_CONSIGNEE_COMPLAINTS " +
						"Set JI_REQUIRED='" + lstJIRequired.SelectedValue + "',NO_JI_REASON='" + lslNOJIReasons.SelectedValue + "',NO_JI_OTHER='" + no_ji_other + "',USER_ID='" + Session["Uname"] + "',DATETIME=to_date('" + wDate + "','dd/mm/yyyy-HH24:MI:SS') " +
						"Where COMPLAINT_ID='" + lblComplaintId.Text + "'";


				}
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

				conn1.Open();
				OracleCommand cmd = new OracleCommand(MySql1, conn1);
				cmd.ExecuteNonQuery();
				conn1.Close();

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
				conn1.Close();
				conn1.Dispose();
			}

			if (lstJIRequired.SelectedValue == "Y")
			{
				send_IE_Email();
			}


		}
		void send_IE_Email()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string wRegion = "";
				if (Session["Region"].ToString() == "N") { wRegion = "CONTROLLING MANAGER (JI/NR) \n 12th FLOOR,CORE-II,SCOPE MINAR,LAXMI NAGAR, DELHI - 110092 \n Phone : 011-22029101 \n Fax : 011-22024665"; }
				else if (Session["Region"].ToString() == "S") { wRegion = "CONTROLLING MANAGER (JI/SR) \n CTS BUILDING - 2ND FLOOR, BSNL COMPLEX, NO. 16, GREAMS ROAD,  CHENNAI - 600 006 \n Phone : 044-28292807/044- 28292817 \n Fax : 044-28290359"; }
				else if (Session["Region"].ToString() == "E") { wRegion = "CONTROLLING MANAGER (JI/ER) \n CENTRAL STATION BUILDING(METRO), 56, C.R. AVENUE,3rd FLOOR,KOLKATA-700 012  \n Fax : 033-22348704"; }
				else if (Session["Region"].ToString() == "W") { wRegion = "CONTROLLING MANAGER (JI/WR) \n 5TH FLOOR, REGENT CHAMBER, ABOVE STATUS RESTAURANT,NARIMAN POINT,MUMBAI-400021 \n Phone : 022-68943400/68943445"; }
				else if (Session["Region"].ToString() == "C") { wRegion = "CONTROLLING MANAGER (JI/CR)"; }

				OracleCommand cmd_vend = new OracleCommand("Select IE_NAME,IE_EMAIL,CO_EMAIL from T20_IC T20, T09_IE T09, T08_IE_CONTROLL_OFFICER T08 where T20.IE_CD=T09.IE_CD and T20.CO_CD=T08.CO_CD(+) and CASE_NO= '" + lblCaseNo.Text + "' and BK_NO='" + txtBKNo.Text + "' and SET_NO='" + txtSetNo.Text + "'", conn1);
				conn1.Open();
				OracleDataReader reader = cmd_vend.ExecuteReader();
				string ie_name = "", ie_email = "", co_email = "";
				while (reader.Read())
				{
					ie_name = Convert.ToString(reader["IE_NAME"]);
					ie_email = Convert.ToString(reader["IE_EMAIL"]);
					co_email = Convert.ToString(reader["CO_EMAIL"]);

				}
				conn1.Close();
				string mail_body = "";
				if (lblCaseNo.Text.Substring(0, 1) == Session["Region"].ToString())
				{
					mail_body = "Dear " + ie_name + ",\n\n Rejection Advice has Registered Vide Complaint No: " + lblComplaintId.Text + ", Dated:" + lblComplaintDt.Text + " \n Consignee: " + lblConsignee.Text + " \n PO No. - " + lblPONO.Text + " \n Book No -  " + txtBKNo.Text + " & Set No - " + txtSetNo.Text + " \n Vendor -" + lblVend.Text + " \n Item- " + lblITEM.Text + " \n Rejected Qty -" + lblQTYREJ.Text + " \n Rejection Memo No. " + HyperLink1.Text + " \n Reason for Rejection -" + txtRejReason.Text + ". \n\n You are requested to send your comments on the rejection at TOP Prioity.\n NATIONAL INSPECTION HELP LINE NUMBER : 1800 425 7000 (TOLL FREE). \n\n " + wRegion + ".";
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
					mail_body = mail_body + " Rejection Advice has Registered Vide Complaint No: " + lblComplaintId.Text + ", Dated:" + lblComplaintId.Text + " \n Consignee: " + lblConsignee.Text + " \n PO No. - " + lblPONO.Text + " \n Book No -  " + txtBKNo.Text + " & Set No - " + txtSetNo.Text + " \n Vendor -" + lblVend.Text + " \n Item- " + lblITEM.Text + " \n Rejected Qty -" + lblQTYREJ.Text + " \n Rejection Memo No. " + HyperLink1.Text + " \n Reason for Rejection -" + txtRejReason.Text + ". \n\n You are requested to send complete Inspection Case with comments for arranging JI at TOP Prioity. \n\n" + wRegion + ".";

				}
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
				string cc = "";

				if (lblCaseNo.Text.Substring(0, 1) == "N")
				{
					cc = "nrinspn@rites.com;pklal@rites.com;sbu.ninsp@rites.com";
				}
				else if (lblCaseNo.Text.Substring(0, 1) == "W")
				{
					cc = "wrinspn@rites.com;harisankarprasad@rites.com;sbu.winsp@rites.com";
				}
				else if (lblCaseNo.Text.Substring(0, 1) == "E")
				{
					cc = "erinspn@rites.com;dksinha1958@hotmail.com;sbu.einsp@rites.com";
				}
				else if (lblCaseNo.Text.Substring(0, 1) == "S")
				{
					cc = "srinspn@rites.com;ravis@rites.com;ravis@rites.com;sbu.sinsp@rites.com";
				}

				conn1.Open();
				OracleCommand myCommand = new OracleCommand("select IE_EMAIL from T09_IE where IE_CD= " + lstJIIE.SelectedValue, conn1);
				string JI_IE = Convert.ToString(myCommand.ExecuteScalar());
				conn1.Close();

				if (lblCaseNo.Text.Substring(0, 1) == Session["Region"].ToString())
				{
					MailMessage mail = new MailMessage();
					mail.To = ie_email + ";" + co_email;
					mail.Cc = cc + ";" + JI_IE;
					//mail.From = sender;
					mail.From = "nrinspn@gmail.com";
					mail.Subject = "Rejection Advice Has Been Registered for Joint Inspection (JI)";
					mail.Body = mail_body;
					mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
					SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
					mail.Priority = MailPriority.High;
					SmtpMail.Send(mail);
				}
				else
				{
					if (Session["Region"].ToString() == "N")
					{
						cc = cc + ";nrinspn@rites.com;pklal@rites.com;sbu.ninsp@rites.com";
					}
					else if (Session["Region"].ToString() == "S")
					{
						cc = cc + ";srinspn@rites.com;ravis@rites.com;ravis@rites.com;sbu.sinsp@rites.com";
					}
					else if (Session["Region"].ToString() == "W")
					{
						cc = cc + ";wrinspn@rites.com;harisankarprasad@rites.com;sbu.winsp@rites.com";
					}
					else if (Session["Region"].ToString() == "E")
					{
						cc = cc + ";erinspn@rites.com;ercomplaints@gmail.com;sbu.einsp@rites.com";
					}
					MailMessage mail = new MailMessage();
					mail.To = cc + ";" + JI_IE;
					mail.Cc = ie_email + ";" + co_email;
					//mail.From = sender;
					mail.From = "nrinspn@gmail.com";
					mail.Subject = "Rejection Advice Has Been Registered for Joint Inspection (JI)";
					mail.Body = mail_body;
					mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
					SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
					mail.Priority = MailPriority.High;
					SmtpMail.Send(mail);

				}


			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
			}
		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		private string generate_complaint_id()
		{
			string wComplaintId = "";
			try
			{
				//				conn1= new System.Data.OracleClient.OracleConnection((ConfigurationSettings.AppSettings["ConnectionString"])) ;

				OracleCommand cmd = new OracleCommand("GENERATE_COMPLAINT_NO", conn1);
				cmd.CommandType = CommandType.StoredProcedure;
				conn1.Open();

				OracleParameter prm1 = new OracleParameter("IN_REGION_CD", System.Data.OracleClient.OracleType.Char);
				prm1.Direction = ParameterDirection.Input;
				prm1.Value = Session["Region"].ToString();
				cmd.Parameters.Add(prm1);

				OracleParameter prm2 = new OracleParameter("IN_COMPLAINT_DT", System.Data.OracleClient.OracleType.Char);
				prm2.Direction = ParameterDirection.Input;
				prm2.Value = Convert.ToString(lblComplaintDt.Text);
				cmd.Parameters.Add(prm2);

				OracleParameter prm3 = new OracleParameter("OUT_COMPLAINT_NO", OracleDbType.Char, 12);
				prm3.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(prm3);

				OracleParameter prm4 = new OracleParameter("OUT_ERR_CD", OracleDbType.Int32);
				prm4.Direction = ParameterDirection.Output;
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
				conn1.Close();
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
				conn1.Close();
				//				conn1.Dispose();
			}
		}
		private string generate_ji_sno()
		{
			string wJiSno = "";
			try
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

				OracleCommand cmd = new OracleCommand("GENERATE_JI_SNO", conn1);
				cmd.CommandType = CommandType.StoredProcedure;
				conn1.Open();

				OracleParameter prm1 = new OracleParameter("IN_INSP_REGION", System.Data.OracleClient.OracleType.Char);
				prm1.Direction = ParameterDirection.Input;
				prm1.Value = lblCaseNo.Text.Substring(0, 1);
				cmd.Parameters.Add(prm1);

				OracleParameter prm2 = new OracleParameter("IN_JI_REGION", System.Data.OracleClient.OracleType.Char);
				prm2.Direction = ParameterDirection.Input;
				prm2.Value = lstJiRegion.SelectedValue;
				cmd.Parameters.Add(prm2);

				OracleParameter prm3 = new OracleParameter("IN_COMPLAINT_DT", System.Data.OracleClient.OracleType.Char);
				prm3.Direction = ParameterDirection.Input;
				prm3.Value = Convert.ToString(lblJIDt.Text);
				cmd.Parameters.Add(prm3);

				OracleParameter prm4 = new OracleParameter("OUT_JI_SNO", OracleDbType.Char, 13);
				prm4.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(prm4);

				OracleParameter prm5 = new OracleParameter("OUT_ERR_CD", OracleDbType.Int32);
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
				conn1.Close();
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
				conn1.Close();
				conn1.Dispose();
			}
		}
		private void fill_JIIE_Cd()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			lstJIIE.Items.Clear();
			DataSet ds = new DataSet();
			OracleCommand cmd = new OracleCommand("Select IE_CD,IE_NAME From T09_IE where IE_REGION='" + lstJiRegion.SelectedValue + "' order by IE_NAME", conn1);
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
			conn1.Close();
			conn1.Dispose();

		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			OracleCommand MyCmd = new OracleCommand("select to_char(sysdate,'dd/mm/yyyy') from dual", conn1);
			string wDate = Convert.ToString(MyCmd.ExecuteScalar());
			lblComplaintDt.Text = wDate;
			conn1.Close();
			string MySql = "";
			//string MyMsg="";
			//
			try
			{
				DataSet reader = new DataSet();
				conn1.Open();
				string str1 = "select REJ_MEMO_NO,to_char(REJ_MEMO_DT,'DD/MM/YYYY') REJ_MEMO_DATE,CASE_NO," +
					"BK_NO,SET_NO,INSP_REGION,IE_CD,CO_CD,CONSIGNEE_CD,VEND_CD,ITEM_SRNO_PO,ITEM_DESC," +
					"QTY_OFFERED,QTY_REJECTED,UOM_CD,RATE,REJECTION_VALUE,REJECTION_REASON from TEMP_ONLINE_COMPLAINTS  where CASE_NO= '" + lblCaseNo.Text + "' and BK_NO='" + txtBKNo.Text + "' and SET_NO='" + txtSetNo.Text + "' ";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand cmd = new OracleCommand(str1, conn1);

				da.SelectCommand = cmd;
				da.Fill(reader, "Table");
				conn1.Close();

				OracleCommand cmd12 = new OracleCommand("Select COMPLAINT_ID from T40_CONSIGNEE_COMPLAINTS where BK_NO='" + reader.Tables[0].Rows[0]["BK_NO"].ToString() + "' and SET_NO='" + reader.Tables[0].Rows[0]["SET_NO"].ToString() + "' and CASE_NO='" + reader.Tables[0].Rows[0]["CASE_NO"].ToString() + "'", conn1);
				conn1.Open();
				string bscheck = Convert.ToString(cmd12.ExecuteScalar());
				conn1.Close();
				if (bscheck == "")
				{

					lblComplaintId.Text = generate_complaint_id();
					MySql = "Insert into T40_CONSIGNEE_COMPLAINTS(COMPLAINT_ID,COMPLAINT_DT,REJ_MEMO_NO,REJ_MEMO_DT,CASE_NO," +
						"BK_NO,SET_NO,INSP_REGION,IE_CD,IE_CO_CD,COMP_RECV_REGION,CONSIGNEE_CD,VEND_CD,ITEM_SRNO_PO,ITEM_DESC," +
						"QTY_OFFERED,QTY_REJECTED,UOM_CD,RATE,REJECTION_VALUE,REJECTION_REASON,USER_ID,DATETIME) " +
						"values " +
						"('" + lblComplaintId.Text + "',to_date('" + wDate + "','dd/mm/yyyy'),'" + Convert.ToString(reader.Tables[0].Rows[0]["REJ_MEMO_NO"]).ToString() + "',to_date('" + Convert.ToString(reader.Tables[0].Rows[0]["REJ_MEMO_DATE"]).ToString() + "','dd/mm/yyyy'),'" + Convert.ToString(reader.Tables[0].Rows[0]["CASE_NO"]).ToString() +
						"','" + Convert.ToString(reader.Tables[0].Rows[0]["BK_NO"]).ToString() + "','" + Convert.ToString(reader.Tables[0].Rows[0]["SET_NO"]).ToString() + "',substr('" + Convert.ToString(reader.Tables[0].Rows[0]["CASE_NO"]).ToString() + "',1,1)," + Convert.ToString(reader.Tables[0].Rows[0]["IE_CD"]).ToString() + "," + Convert.ToString(reader.Tables[0].Rows[0]["CO_CD"]).ToString() + ",'" + Session["Region"].ToString() + "'," + Convert.ToString(reader.Tables[0].Rows[0]["CONSIGNEE_CD"]).ToString() +
						"," + Convert.ToString(reader.Tables[0].Rows[0]["VEND_CD"]).ToString() + "," + Convert.ToString(reader.Tables[0].Rows[0]["ITEM_SRNO_PO"]).ToString() + ",'" + Convert.ToString(reader.Tables[0].Rows[0]["ITEM_DESC"]).ToString() + "'," + Convert.ToString(reader.Tables[0].Rows[0]["QTY_OFFERED"]).ToString() + "," + Convert.ToString(reader.Tables[0].Rows[0]["QTY_REJECTED"]).ToString() + ",'" + Convert.ToString(reader.Tables[0].Rows[0]["UOM_CD"]).ToString() + "'," + Convert.ToString(reader.Tables[0].Rows[0]["RATE"]).ToString() + "," + Convert.ToString(reader.Tables[0].Rows[0]["REJECTION_VALUE"]).ToString() + ",'" + Convert.ToString(reader.Tables[0].Rows[0]["REJECTION_REASON"]).ToString() +
						"','" + Session["Uname"] + "',to_date('" + wDate + "','dd/mm/yyyy'))";
					conn1.Open();
					OracleCommand cmd1 = new OracleCommand(MySql, conn1);
					cmd1.ExecuteNonQuery();
					conn1.Close();
					string mySql11 = "Update TEMP_ONLINE_COMPLAINTS SET STATUS='A',COMPLAINT_ID='" + lblComplaintId.Text + "' WHERE TEMP_COMPLAINT_ID='" + lblTempCompID.Text + "' ";
					conn1.Open();
					OracleCommand cmd11 = new OracleCommand(mySql11, conn1);
					cmd11.ExecuteNonQuery();
					conn1.Close();

					//				MyMsg="Complaint Id -> "+lblComplaintId.Text;
					//				DisplayAlert(MyMsg);
					btnReject.Visible = false;
					Label8.Visible = false;
					txtRejReason.Visible = false;
					btnSaveReject.Visible = false;
					lblComplaintId.Visible = true;
					Label20.Visible = true;
					lblComplaintDt.Visible = true;
					Label19.Visible = true;
					Label21.Visible = true;
					lstJIRequired.Visible = true;
					lblJiSrNo.Visible = false;
					btnSave.Enabled = false;


					try
					{
						string MyFile = lblCaseNo.Text.Trim() + "-" + txtBKNo.Text.Trim() + "-" + txtSetNo.Text.Trim();
						File.Copy(Server.MapPath("..") + @"/RBS/Online_Complaints/" + lblTempCompID.Text + ".PDF", Server.MapPath("..") + @"/RBS/REJECTION_MEMO/" + MyFile + ".PDF");
						DisplayAlert("File Copied!!!");
						//DisplayAlert(Server.MapPath(".."));

					}
					catch (Exception ex)
					{
						string str;
						str = ex.Message;
						DisplayAlert(Server.MapPath("..") + " & " + str);
					}
				}
				else
				{
					DisplayAlert("Complaint Already Registered with the Given BK_NO, SET_NO & CASE_NO");
				}
				//				lslNOJIReasons.Visible=true;
				//				Label14.Visible=true;
				//				lstJiRegion.Visible=true;
				//				lstJiRegion.Visible=true;
				//				Label19.Visible=true;
				//				Label32.Visible=true;
				//				lstJIIE.Visible=true;
				//				Label29.Visible=true;
				//				txtJIFixDT.Visible=true;


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

		protected void btnCancel3_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("MainForm.aspx");
		}

		protected void btnCancel1_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Online_complaints_Approval_Form.aspx");
		}

		protected void btnSaveReject_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string mySql = "Update TEMP_ONLINE_COMPLAINTS SET STATUS='R', TEMP_COMP_REJ_REASON='" + txtRejReason.Text.Trim() + "' WHERE TEMP_COMPLAINT_ID='" + lblTempCompID.Text + "' ";
				conn1.Open();
				OracleCommand cmd1 = new OracleCommand(mySql, conn1);
				cmd1.ExecuteNonQuery();
				conn1.Close();
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
			send_Consignee_Email_for_Rejected_Complaints();


		}


		void send_Consignee_Email_for_Rejected_Complaints()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string wRegion = "";

				string sender = "";
				if (Session["Region"].ToString() == "N") { wRegion = "NORTHERN REGION \n 12th FLOOR,CORE-II,SCOPE MINAR,LAXMI NAGAR, DELHI - 110092 \n Phone : +918800018691-95 \n Fax : 011-22024665"; sender = "nrinspn@rites.com"; }
				else if (Session["Region"].ToString() == "S") { wRegion = "SOUTHERN REGION \n CTS BUILDING - 2ND FLOOR, BSNL COMPLEX, NO. 16, GREAMS ROAD,  CHENNAI - 600 006 \n Phone : 044-28292807/044- 28292817 \n Fax : 044-28290359"; sender = "srinspn@rites.com"; }
				else if (Session["Region"].ToString() == "E") { wRegion = "EASTERN REGION \n CENTRAL STATION BUILDING(METRO), 56, C.R. AVENUE,3rd FLOOR,KOLKATA-700 012  \n Fax : 033-22348704"; sender = "erinspn@rites.com"; }
				else if (Session["Region"].ToString() == "W") { wRegion = "WESTERN REGION \n 5TH FLOOR, REGENT CHAMBER, ABOVE STATUS RESTAURANT, NARIMAN POINT,MUMBAI-400021 \n Phone : 022-68943400/68943445"; sender = "wrinspn@rites.com"; }
				else if (Session["Region"].ToString() == "C") { wRegion = "Central Region"; }

				OracleCommand cmd_vend = new OracleCommand("Select CONSIGNEE_NAME, CONSIGNEE_DESIG, CONSIGNEE_EMAIL, CONSIGNEE_MOBILE, REJ_MEMO_NO, TO_CHAR(REJ_MEMO_DT,'DD/MM/YYYY') REJ_MEMO_DATE  from TEMP_ONLINE_COMPLAINTS where COMPLAINT_NO='" + lblTempCompID.Text + "'", conn1);
				conn1.Open();
				OracleDataReader reader = cmd_vend.ExecuteReader();
				string consignee = "", consignee_email = "", rej_memo_dt = "", rej_memo_no = "";
				while (reader.Read())
				{
					consignee = Convert.ToString(reader["CONSIGNEE_NAME"]);
					consignee_email = Convert.ToString(reader["CONSIGNEE_EMAIL"]);
					rej_memo_no = Convert.ToString(reader["REJ_MEMO_NO"]);
					rej_memo_dt = Convert.ToString(reader["REJ_MEMO_DATE"]);

				}
				conn1.Close();

				//				OracleCommand cmd =new OracleCommand("Select T05.VEND_EMAIL,T17.MFG_CD from T05_VENDOR T05,T17_CALL_REGISTER T17 where T05.VEND_CD=T17.MFG_CD and CASE_NO='"+txtCaseNo.Text.Trim()+"' and CALL_RECV_DT=to_date('"+txtDtOfReciept.Text+"','dd/mm/yyyy') and CALL_SNO="+lblCSNO.Text,conn1);
				//				conn1.Open();
				//				string manu_mail="";
				//				string mfg_cd="";
				//				OracleDataReader reader1 = cmd.ExecuteReader();
				//				while(reader1.Read())
				//				{
				//					manu_mail=Convert.ToString(reader1["VEND_EMAIL"]);
				//					mfg_cd=Convert.ToString(reader1["MFG_CD"]);
				//				
				//				}
				//				
				//				conn1.Close();
				//				OracleCommand cmd1 =new OracleCommand("Select IE_PHONE_NO from T09_IE where IE_CD="+lstIE.SelectedValue,conn1);
				//				conn1.Open();
				//				string ie_phone=Convert.ToString(cmd1.ExecuteScalar());
				//				conn1.Close();
				string call_letter_dt = "";
				if (rej_memo_dt.ToString().Trim() == "")
				{
					call_letter_dt = "NIL";
				}
				else
				{
					call_letter_dt = rej_memo_dt;
				}
				string mail_body = "Dear Sir/Madam,\n\n Online Consignee Complaint vide Rej Memo Letter dated:  " + call_letter_dt + " for JI of material against PO No. - " + lblPONO.Text + " dated - " + lblPODT.Text + ", on date: " + lblTempCompDt.Text + ". The Complaint is rejected due to following Reason:- " + txtRejReason.Text + ", so Complaint not registered. \n\n Thanks for using RITES Inspection Services. \n NATIONAL INSPECTION HELP LINE NUMBER : 1800 425 7000 (TOLL FREE). \n\n" + wRegion + ".";



				if (consignee_email != "")
				{
					MailMessage mail = new MailMessage();
					mail.To = consignee_email;
					mail.Bcc = "nrinspn@gmail.com";
					//mail.From = sender;
					mail.From = "nrinspn@gmail.com";
					mail.Subject = "Your Consignee Complaint For RITES";
					mail.Body = mail_body;
					mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
					SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
					mail.Priority = MailPriority.High;
					SmtpMail.Send(mail);
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

		protected void lstJiRegion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lstJiRegion.SelectedValue == Session["Region"].ToString())
			{
				fill_JIIE_Cd();
				Label32.Visible = true;
				lstJIIE.Visible = true;
				Label29.Visible = true;
				txtJIFixDT.Visible = true;

			}
			else
			{
				lstJIIE.Items.Clear();
				Label32.Visible = false;
				lstJIIE.Visible = false;
				Label29.Visible = false;
				txtJIFixDT.Visible = false;

			}
		}

		protected void btnTempComp_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("/RBS/Online_complaints_Approval_Form.aspx");

		}

		protected void lslNOJIReasons_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lslNOJIReasons.SelectedValue == "K")
			{
				txtNoJIOthers.Visible = true;
				Label24.Visible = true;
			}
			else
			{
				txtNoJIOthers.Visible = false;
				Label24.Visible = false;
			}
		}

		//		private void grdCNO_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		//		{
		//			string fpath=Server.MapPath("/RBS/");
		//			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
		//			{
		//				fpath=fpath+Convert.ToString(e.Item.Cells[10].Text);
		//				if (File.Exists(fpath)==false) 
		//				{
		//					e.Item.Cells[10].Text="<Font Face=Verdana Color=RED>No File</Font>";
		//				}
		//				else
		//				{
		//					e.Item.Cells[10].Text="<a href="+Convert.ToString(e.Item.Cells[10].Text)+">Download REJ MEMO</a>";
		//				}
		//			}		
		//		}
	}
}