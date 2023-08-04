using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Copy_of_IE_JI_Remarks_Entry_Form
{
	public partial class JI_IE_Remarks_Entry_Form : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblVend;
		protected System.Web.UI.WebControls.Label lblItem;
		protected System.Web.UI.WebControls.Label lblPONO;
		protected System.Web.UI.WebControls.Label lblCSNO;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnSave;
		string wIECD;
		protected System.Web.UI.WebControls.TextBox txtSTDT;
		protected System.Web.UI.WebControls.Panel Panel_1;
		protected System.Web.UI.WebControls.Label Label32;
		protected System.Web.UI.WebControls.TextBox txtRemarks;
		protected System.Web.UI.WebControls.Label lblComplID;
		protected System.Web.UI.WebControls.Label lblConsignee;
		protected System.Web.UI.WebControls.Label lblQtyOff;
		protected System.Web.UI.WebControls.Label lblQtyREJ;
		protected System.Web.UI.WebControls.Label lblValOfRej;
		protected System.Web.UI.WebControls.Label lblReasonOfRej;
		protected System.Web.UI.WebControls.Label lblBkNo;
		protected System.Web.UI.WebControls.Label lblRejMemoNo;
		protected System.Web.UI.WebControls.Label lblICNo;
		protected System.Web.UI.WebControls.Label lblSetNo;
		protected System.Web.UI.WebControls.Label lblIEJIRemarks;
		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);


		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			if (Convert.ToString(Request.Params["COMPLAINT_ID"]) != null)
			{
				lblComplID.Text = Convert.ToString(Request.Params["COMPLAINT_ID"].Trim());
			}

			if (!(IsPostBack))
			{
				conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				string sql = "Select to_char(COMPLAINT_DT,'dd/mm/yyyy')COMPLAINT_DATE,REJ_MEMO_NO,to_char(REJ_MEMO_DT,'dd/mm/yyyy')REJ_MEMO_DATE,CASE_NO,BK_NO,SET_NO," +
					"trim(PO_NO)||' dated- '||to_char(PO_DT,'dd/mm/yyyy') PO,RLY_CD,IC_NO, to_char(IC_DT,'dd/mm/yyyy') IC_DT,IE_NAME,IE_CO_CD," +
					"(CONSIGNEE_NAME||'/'||CONSIGNEE_ADDR)CONSIGNEE,VENDOR,ITEM_SRNO_PO,ITEM_DESC,QTY_OFFERED,QTY_REJECTED,UOM_CD,UOM_S_DESC,RATE,REJECTION_VALUE," +
					"REJECTION_REASON,IE_JI_REMARKS From V40_CONSIGNEE_COMPLAINTS Where COMPLAINT_ID='" + lblComplID.Text + "'";

				try
				{
					OracleCommand cmd = new OracleCommand();
					cmd.CommandText = sql;
					cmd.Connection = conn;
					conn.Open();
					OracleDataReader readerB = cmd.ExecuteReader();
					while (readerB.Read())
					{
						lblVend.Text = Convert.ToString(readerB["VENDOR"]);
						lblConsignee.Text = Convert.ToString(readerB["CONSIGNEE"]);
						lblItem.Text = Convert.ToString(readerB["ITEM_DESC"]);
						lblPONO.Text = Convert.ToString(readerB["PO"]);
						lblCSNO.Text = Convert.ToString(readerB["CASE_NO"]);
						lblBkNo.Text = Convert.ToString(readerB["BK_NO"]);
						lblSetNo.Text = Convert.ToString(readerB["SET_NO"]);
						lblICNo.Text = Convert.ToString(readerB["IC_NO"]) + " & " + Convert.ToString(readerB["IC_DT"]);
						lblRejMemoNo.Text = Convert.ToString(readerB["REJ_MEMO_NO"]) + " & " + Convert.ToString(readerB["REJ_MEMO_DATE"]);
						lblQtyOff.Text = Convert.ToString(readerB["QTY_OFFERED"]);
						lblQtyREJ.Text = Convert.ToString(readerB["QTY_REJECTED"]);
						lblValOfRej.Text = Convert.ToString(readerB["REJECTION_VALUE"]);
						lblReasonOfRej.Text = Convert.ToString(readerB["REJECTION_REASON"]);
						lblIEJIRemarks.Text = Convert.ToString(readerB["IE_JI_REMARKS"]);


					}
					OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual", conn);
					txtSTDT.Text = Convert.ToString(cmd2.ExecuteScalar());

					conn.Close();

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
					conn.Dispose();
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
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Reports/pfrmFromToDate.aspx?action=PJI");
		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}




		private void btnSave_Click(object sender, System.EventArgs e)
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string updateQuery = "Update T40_CONSIGNEE_COMPLAINTS set JI_IE_REMARKS='" + txtRemarks.Text.Trim() + "',JI_IE_REMARKS_DT=to_date('" + txtSTDT.Text + "','dd/mm/yyyy') where COMPLAINT_ID='" + lblComplID.Text.Trim() + "' ";
				OracleCommand myUpdateCommand = new OracleCommand(updateQuery, conn);
				conn.Open();
				myUpdateCommand.ExecuteNonQuery();
				conn.Close();

				DisplayAlert("Your Record is Saved!!!");




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
				conn.Dispose();
			}

			send_IE_Email();
		}


		void send_IE_Email()
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string wRegion = "";
				if (Session["Region"].ToString() == "N") { wRegion = "IE (NR) \n 12th FLOOR,CORE-II,SCOPE MINAR,LAXMI NAGAR, DELHI - 110092 \n Phone : 011-22029101 \n Fax : 011-22024665"; }
				else if (Session["Region"].ToString() == "S") { wRegion = "IE (SR) \n 758 ANNA SALAI [MOUNT CHAMBER], CHENNAI - 600 002 \n Phone : 044-28523364/044-28524128 \n Fax : 044-28525408"; }
				else if (Session["Region"].ToString() == "E") { wRegion = "IE (ER) \n CENTRAL STATION BUILDING(METRO), 56, C.R. AVENUE,3rd FLOOR,KOLKATA-700 012  \n Fax : 033-22348704"; }
				else if (Session["Region"].ToString() == "W") { wRegion = "IE (WR) \n CHURCHGATE STATION BLDG., 2nd FLOOR, M.K ROAD,MUMBAI-400 020 \n Phone : 022-22012523/022-22015573 \n Fax : 022-22081455/022-22016220"; }
				else if (Session["Region"].ToString() == "C") { wRegion = "IE (CR)"; }

				OracleCommand cmd_vend = new OracleCommand("Select IE_NAME,IE_EMAIL,CO_EMAIL from T20_IC T20, T09_IE T09, T08_IE_CONTROLL_OFFICER T08 where T20.IE_CD=T09.IE_CD and T20.CO_CD=T08.CO_CD(+) and CASE_NO='" + lblCSNO.Text.Trim() + "' and BK_NO='" + lblBkNo.Text.Trim() + "' and SET_NO='" + lblSetNo.Text.Trim() + "'", conn);
				conn.Open();
				OracleDataReader reader = cmd_vend.ExecuteReader();
				string ie_name = "", ie_email = "", co_email = "";
				while (reader.Read())
				{
					ie_name = Convert.ToString(reader["IE_NAME"]);
					ie_email = Convert.ToString(reader["IE_EMAIL"]);
					co_email = Convert.ToString(reader["CO_EMAIL"]);

				}
				conn.Close();
				string mail_body = "";
				if (lblCSNO.Text.Substring(0, 1) == Session["Region"].ToString())
				{
					if (lblCSNO.Text.Substring(0, 1) == "N")
					{
						mail_body = "Controlling Manager (JI/NR), \n\n ";
					}
					else if (lblCSNO.Text.Substring(0, 1) == "W")
					{
						mail_body = "Controlling Manager (JI/WR), \n\n ";
					}
					else if (lblCSNO.Text.Substring(0, 1) == "E")
					{
						mail_body = "Controlling Manager (JI/ER), \n\n ";
					}
					else if (lblCSNO.Text.Substring(0, 1) == "S")
					{
						mail_body = "Controlling Manager (JI/SR), \n\n ";
					}
					mail_body = " JI Engineer had Submitted his remarks Vide Complaint No: " + lblComplID.Text + "\n Consignee: " + lblConsignee.Text + " \n PO No. - " + lblPONO.Text + " \n Book No -  " + lblBkNo.Text + " & Set No - " + lblSetNo.Text + " \n Vendor -" + lblVend.Text + " \n Item- " + lblItem.Text + " \n Rejected Qty -" + lblQtyREJ.Text + " \n Rejection Memo No. & Dated " + lblRejMemoNo.Text + "\n Reason for Rejection -" + lblReasonOfRej.Text + " \n\n JI Engineer Remarks: " + txtRemarks.Text + ", Dated: " + txtSTDT.Text + " \n\n " + ie_name + " \n" + wRegion + ".";

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

				if (lblCSNO.Text.Substring(0, 1) == "N")
				{
					cc = "nrinspn@rites.com;rajnishahuja@rites.com";
				}
				else if (lblCSNO.Text.Substring(0, 1) == "W")
				{
					cc = "wrinspn@rites.com;ramendra_harshita@yahoo.com";
				}
				else if (lblCSNO.Text.Substring(0, 1) == "E")
				{
					cc = "erinspn@rites.com;amit05@mail.com;amit0559@gmail.com";
				}
				else if (lblCSNO.Text.Substring(0, 1) == "S")
				{
					cc = "srinspn@rites.com;sravi1968@gmail.com";
				}

				conn.Open();
				OracleCommand myCommand = new OracleCommand("select IE_EMAIL from T09_IE T09, T40_CONSIGNEE_COMPLAINTS T40 where T40.JI_IE_CD=T09.IE_CD and COMPLAINT_ID= '" + lblComplID.Text + "'", conn);
				string JI_IE = Convert.ToString(myCommand.ExecuteScalar());
				conn.Close();

				if (lblCSNO.Text.Substring(0, 1) == Session["Region"].ToString())
				{
					MailMessage mail = new MailMessage();
					mail.To = ie_email + ";" + co_email;
					mail.Cc = cc + ";" + JI_IE;
					mail.From = sender;
					mail.Subject = "IE Remarks against Consignee Complaint Has Been Registered for Joint Inspection (JI)";
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
						cc = cc + ";nrinspn@rites.com;rajnishahuja@rites.com";
					}
					else if (Session["Region"].ToString() == "S")
					{
						cc = cc + ";srinspn@rites.com;sravi1968@gmail.com";
					}
					else if (Session["Region"].ToString() == "W")
					{
						cc = cc + ";wrinspn@rites.com;ramendra_harshita@yahoo.com";
					}
					else if (Session["Region"].ToString() == "E")
					{
						cc = cc + ";erinspn@rites.com;amit05@mail.com;amit0559@gmail.com";
					}
					MailMessage mail = new MailMessage();
					mail.To = cc + ";" + JI_IE;
					mail.Cc = ie_email + ";" + co_email;
					mail.From = sender;
					mail.Subject = "IE Remarks against Consignee Complaint Has Been Registered for Joint Inspection (JI)";
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
			finally
			{
				conn.Close();
				conn.Dispose();
			}
		}



	}
}