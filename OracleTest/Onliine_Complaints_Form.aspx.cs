using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Onliine_Complaints_Form
{
	public partial class Onliine_Complaints_Form : System.Web.UI.Page
	{
		System.Data.OracleClient.OracleConnection MyConn = null;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");

			MyConn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			MyConn.Open();
			OracleCommand MyCmd = new OracleCommand("select to_char(sysdate,'dd/mm/yyyy') from dual", MyConn);
			lblCom_DT.Text = Convert.ToString(MyCmd.ExecuteScalar());

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

		protected void lstPoItems_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			MyConn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			lblItemDesc.Text = lstPoItems.SelectedItem.Text;
			lblItemSrnoPo.Text = lstPoItems.SelectedValue;
			try
			{
				string MySql = "Select t13.CASE_NO,t13.VEND_CD,T20.CONSIGNEE_CD,T20.IE_CD, T20.CO_CD, t15.UOM_CD,round(t15.VALUE/t15.QTY,4)RATE,t04.UOM_S_DESC, T18.QTY_TO_INSP From T15_PO_DETAIL t15,T04_UOM t04,T20_IC T20,T13_PO_MASTER t13, T18_CALL_DETAILS T18 Where t15.CASE_NO =t13.CASE_NO and t13.CASE_NO=T20.CASE_NO and t15.UOM_CD=t04.UOM_CD and T15.CASE_NO=T20.CASE_NO AND T20.CASE_NO=T18.CASE_NO AND T20.CALL_RECV_DT=T18.CALL_RECV_DT AND T20.CALL_SNO=T18.CALL_SNO AND T20.CONSIGNEE_CD=T18.CONSIGNEE_CD and T15.ITEM_SRNO=T18.ITEM_SRNO_PO AND T15.CONSIGNEE_CD=T18.CONSIGNEE_CD and T20.BK_NO='" + txtBkNo.Text + "' AND T20.SET_NO='" + txtSetNo.Text + "' and substr(T20.CASE_NO,1,1)='" + lstINSPRegion.SelectedValue + "' and t15.ITEM_SRNO=" + lblItemSrnoPo.Text;
				MyConn.Open();
				OracleCommand cmd = new OracleCommand(MySql, MyConn);
				OracleDataReader MyReader = cmd.ExecuteReader();
				while (MyReader.Read())
				{
					lblUOM.Text = MyReader["UOM_CD"].ToString();
					lblUOMDesc.Text = MyReader["UOM_S_DESC"].ToString();
					lblRate.Text = MyReader["RATE"].ToString();
					lblUomRate.Text = " per " + lblUOMDesc.Text;
					lblCaseNO.Text = MyReader["CASE_NO"].ToString();
					lblVendor.Text = MyReader["VEND_CD"].ToString();
					lblConsignee.Text = MyReader["CONSIGNEE_CD"].ToString();
					lblIE.Text = MyReader["IE_CD"].ToString();
					lblCO.Text = MyReader["CO_CD"].ToString();
					txtQtyOffered.Text = MyReader["QTY_TO_INSP"].ToString();
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
			txtQtyOffered.Enabled = true;
			txtQtyRej.Enabled = true;
			txtValueRej.Enabled = true;
			txtRejReason.Enabled = true;
			txtRemarks.Enabled = true;
			btnSave.Enabled = true;
			rbs.SetFocus(txtQtyOffered);
		}

		private void fill_lstPoItems()
		{
			MyConn = new System.Data.OracleClient.OracleConnection((ConfigurationSettings.AppSettings["ConnectionString"]));
			lstPoItems.Items.Clear();
			DataSet ds = new DataSet();
			string MySql = "Select t18.ITEM_SRNO_PO,t18.ITEM_DESC_PO From T18_CALL_DETAILS t18,T20_IC t20 " +
				"Where t18.CASE_NO=t20.CASE_NO and t18.CALL_RECV_DT=t20.CALL_RECV_DT and t18.CALL_SNO=t20.CALL_SNO and t18.CONSIGNEE_CD=t20.CONSIGNEE_CD and " +
				"substr(t20.CASE_NO,1,1)='" + lstINSPRegion.SelectedValue + "' and t20.BK_NO='" + txtBkNo.Text + "' and t20.SET_NO='" + txtSetNo.Text + "'";
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

		protected void lstINSPRegion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fill_lstPoItems();
			rbs.SetFocus(lstPoItems);
		}

		protected void txtQtyRej_TextChanged(object sender, System.EventArgs e)
		{
			txtValueRej.Text = Convert.ToString((Convert.ToDecimal(lblRate.Text) * Convert.ToDecimal(txtQtyRej.Text)));
			rbs.SetFocus(txtRejReason);
		}

		private string generate_complaint_id()
		{
			string wComplaintId = "";
			try
			{
				MyConn = new System.Data.OracleClient.OracleConnection((ConfigurationSettings.AppSettings["ConnectionString"]));

				OracleCommand cmd = new OracleCommand("GENERATE_TEMP_COMPLAINT_NO", MyConn);
				cmd.CommandType = CommandType.StoredProcedure;
				MyConn.Open();

				OracleParameter prm2 = new OracleParameter("IN_TEMP_COMPLAINT_DT", System.Data.OracleClient.OracleType.Char);
				prm2.Direction = ParameterDirection.Input;
				prm2.Value = Convert.ToString(lblCom_DT.Text);
				cmd.Parameters.Add(prm2);

				OracleParameter prm3 = new OracleParameter("OUT_TEMP_COMPLAINT_ID", System.Data.OracleClient.OracleType.Char, 8);
				prm3.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(prm3);

				OracleParameter prm4 = new OracleParameter("OUT_ERR_CD", System.Data.OracleClient.OracleType.Number, 1);
				prm4.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(prm4);

				cmd.ExecuteNonQuery();

				if (Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value) == -1)
				{
					wComplaintId = "-1";
				}
				else
				{
					wComplaintId = Convert.ToString(cmd.Parameters["OUT_TEMP_COMPLAINT_ID"].Value);
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

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		void send_Email()
		{
			//			MyConn= new System.Data.OracleClient.OracleConnection((ConfigurationSettings.AppSettings["ConnectionString"])) ;
			try
			{
				string wRegion = "";
				if (lstINSPRegion.SelectedValue.ToString() == "N") { wRegion = "CONTROLLING MANAGER (JI/NR) \n 12th FLOOR,CORE-II,SCOPE MINAR,LAXMI NAGAR, DELHI - 110092 \n Phone : 011-22029101 \n Fax : 011-22024665"; }
				else if (lstINSPRegion.SelectedValue.ToString() == "S") { wRegion = "CONTROLLING MANAGER (JI/SR) \n CTS BUILDING - 2ND FLOOR, BSNL COMPLEX, NO. 16, GREAMS ROAD,  CHENNAI - 600 006 \n Phone : 044-28292807/044- 28292817 \n Fax : 044-28290359"; }
				else if (lstINSPRegion.SelectedValue.ToString() == "E") { wRegion = "CONTROLLING MANAGER (JI/ER) \n CENTRAL STATION BUILDING(METRO), 56, C.R. AVENUE,3rd FLOOR,KOLKATA-700 012  \n Fax : 033-22348704"; }
				else if (lstINSPRegion.SelectedValue.ToString() == "W") { wRegion = "CONTROLLING MANAGER (JI/WR) \n 5TH FLOOR, REGENT CHAMBER, ABOVE STATUS RESTAURANT,NARIMAN POINT,MUMBAI-400021 \n Phone : 022-68943400/68943445"; }
				else if (lstINSPRegion.SelectedValue.ToString() == "C") { wRegion = "CONTROLLING MANAGER (JI/CR)"; }

				//				OracleCommand cmd_vend =new OracleCommand("Select IE_NAME,IE_EMAIL,CO_EMAIL from T20_IC T20, T09_IE T09, T08_IE_CONTROLL_OFFICER T08 where T20.IE_CD=T09.IE_CD and T20.CO_CD=T08.CO_CD(+) and CASE_NO='"+lblCaseNo.Text.Trim()+"' and BK_NO='"+lblBkNo.Text.Trim()+"' and SET_NO='"+lblSetNo.Text.Trim()+"'",Conn);
				//				Conn.Open();
				//				OracleDataReader reader = cmd_vend.ExecuteReader();
				//				string ie_name="",ie_email="",co_email="";
				//				while(reader.Read())
				//				{
				//					ie_name=Convert.ToString(reader["IE_NAME"]);
				//					ie_email=Convert.ToString(reader["IE_EMAIL"]);
				//					co_email=Convert.ToString(reader["CO_EMAIL"]);
				//				
				//				}
				//				Conn.Close();
				string mail_body = "";


				//					mail_body=mail_body +" Complaint has Registered Vide Complaint No: "+lblComplaintId.Text+", Dated:"+txtComplaintDt.Text+" \n Consignee: "+lblConsignee.Text+" \n PO No. - "+lblPoNo.Text+" \n Book No -  " + lblBkNo.Text +" & Set No - "+lblSetNo.Text+" \n Vendor -"+lblVendor.Text+" \n Item- "+lstPoItems.SelectedItem.Text+" \n Rejected Qty -"+txtQtyRej.Text+" \n Rejection Memo No. "+txtMemoDt.Text+" Dated: "+txtMemoDt.Text+" \n Reason for Rejection -"+txtRejReason.Text+". \n\n You are requested to send complete Inspection Case with comments for arranging JI at TOP Prioity. \n\n"+ wRegion +"." ;
				mail_body = "Sir/Mam, \n\n" + "Online Rejection Advice has been Registered Vide Dated:" + lblCom_DT.Text + " \n Consignee Name: " + txtCON_Name.Text + " \n Book No -  " + txtBkNo.Text + " & Set No - " + txtSetNo.Text + " \n Item- " + lstPoItems.SelectedItem.Text + " \n Rejected Qty -" + txtQtyRej.Text + " \n Rejection Memo No. " + txtMemoDt.Text + " Dated: " + txtMemoDt.Text + " \n Reason for Rejection -" + txtRejReason.Text + ".\n NATIONAL INSPECTION HELP LINE NUMBER : 1800 425 7000 (TOLL FREE) \n\n " + wRegion + ".";


				string sender = "";



				if (lstINSPRegion.SelectedValue.ToString() == "N")
				{
					sender = "nrinspn@rites.com";
				}
				else if (lstINSPRegion.SelectedValue.ToString() == "W")
				{
					sender = "wrinspn@rites.com";
				}
				else if (lstINSPRegion.SelectedValue.ToString() == "E")
				{
					sender = "erinspn@rites.com";
				}
				else if (lstINSPRegion.SelectedValue.ToString() == "S")
				{
					sender = "srinspn@rites.com";
				}
				string cc = "";

				if (lstINSPRegion.SelectedValue.ToString() == "N")
				{
					cc = "nrinspn@rites.com;ramendrakumar@rites.com";
				}
				else if (lstINSPRegion.SelectedValue.ToString() == "W")
				{
					cc = "wrinspn@rites.com;";
				}
				else if (lstINSPRegion.SelectedValue.ToString() == "E")
				{
					cc = "erinspn@rites.com;ercomplaints@gmail.com";
				}
				else if (lstINSPRegion.SelectedValue.ToString() == "S")
				{
					cc = "srinspn@rites.com;ravis@rites.com;kbjayan@rites.com";
				}



				MailMessage mail = new MailMessage();
				mail.To = cc;
				mail.Cc = txtCON_Email.Text;
				mail.Bcc = "nrinspn@gmail.com";
				mail.From = sender;
				mail.Subject = "Online Rejection Advice Has Been Registered";
				mail.Body = mail_body;
				mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
				SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
				mail.Priority = MailPriority.High;
				SmtpMail.Send(mail);




			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
			}
		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{

				string MySql = "";
				string fn = "", fx = "", MyFile = "";
				fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
				fx = System.IO.Path.GetExtension(File1.PostedFile.FileName).ToUpper();

				if (File1.PostedFile != null && File1.PostedFile.ContentLength > 0 && fx == ".PDF")
				{
					string comp_id = generate_complaint_id();
					MyConn = new System.Data.OracleClient.OracleConnection((ConfigurationSettings.AppSettings["ConnectionString"]));
					MyConn.Open();
					MySql = "Insert into TEMP_ONLINE_COMPLAINTS(TEMP_COMPLAINT_ID,TEMP_COMPLAINT_DT,CONSIGNEE_NAME,CONSIGNEE_DESIG,CONSIGNEE_EMAIL,CONSIGNEE_MOBILE,BK_NO,SET_NO,INSP_REGION,REJ_MEMO_NO,REJ_MEMO_DT," +
						"ITEM_SRNO_PO,ITEM_DESC,QTY_OFFERED,QTY_REJECTED,UOM_CD,RATE,REJECTION_VALUE,REJECTION_REASON,REMARKS,CASE_NO,VEND_CD,CONSIGNEE_CD,IE_CD,CO_CD) " +
						"values " +
						"('" + comp_id + "',to_date('" + lblCom_DT.Text + "','dd/mm/yyyy'),'" + txtCON_Name.Text + "','" + txtDesig.Text + "','" + txtCON_Email.Text + "','" + txtCON_Contact_NO.Text + "','" + txtBkNo.Text + "','" + txtSetNo.Text + "','" + lstINSPRegion.SelectedValue + "','" + txtMemoNo.Text + "',to_date('" + txtMemoDt.Text + "','dd/mm/yyyy')," + lblItemSrnoPo.Text + ",'" + lblItemDesc.Text + "'," + txtQtyOffered.Text + "," + txtQtyRej.Text + "," + lblUOM.Text + "," + lblRate.Text + "," + txtValueRej.Text + ", " +
						"'" + txtRejReason.Text + "','" + txtRemarks.Text + "','" + lblCaseNO.Text + "'," + lblVendor.Text + "," + lblConsignee.Text + "," + lblIE.Text + "," + lblCO.Text + ")";
					OracleCommand cmd = new OracleCommand(MySql, MyConn);
					cmd.ExecuteNonQuery();
					MyConn.Close();
					MyFile = comp_id;



					String SaveLocation = null;
					SaveLocation = Server.MapPath("Online_Complaints/" + MyFile + "." + "pdf");
					File1.PostedFile.SaveAs(SaveLocation);
					send_Email();
					DisplayAlert("Complaint is registered!!!");
					txtCON_Name.Text = "";
					txtDesig.Text = "";
					txtCON_Email.Text = "";
					txtCON_Contact_NO.Text = "";
					txtBkNo.Text = "";
					txtSetNo.Text = "";
					lstINSPRegion.SelectedValue = "";
					lstPoItems.Items.Clear();
					txtQtyOffered.Text = "";
					txtQtyRej.Text = "";
					txtRejReason.Text = "";
					txtRemarks.Text = "";
					txtMemoNo.Text = "";
					txtMemoDt.Text = "";



				}
				else
				{
					DisplayAlert("Please select a PDF file to upload.");
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
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("www.ritesinsp.com");
		}

	}
}