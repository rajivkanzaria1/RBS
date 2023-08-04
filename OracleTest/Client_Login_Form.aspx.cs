using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Client_Login_Form
{
	public partial class Client_Login_Form : System.Web.UI.Page
	{
		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);


		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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

		protected void btnLogin_Click(object sender, System.EventArgs e)
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				conn.Open();
				OracleCommand cmd11 = new OracleCommand("Select to_char(sysdate,'DD/MM/YYYY-HH24:MI:SS') GEN_TIME,TO_CHAR(SYSDATE+ interval '10' minute,'DD/MM/YYYY-HH24:MI:SS') EXP_TIME from dual", conn);
				//				string sdate=Convert.ToString(cmd11.ExecuteScalar());
				OracleDataReader reader1 = cmd11.ExecuteReader();
				string gen_time = "", exp_time = "";
				while (reader1.Read())
				{
					gen_time = reader1["GEN_TIME"].ToString();
					exp_time = reader1["EXP_TIME"].ToString();
				}

				conn.Close();
				lblGen_Time.Text = gen_time;

				//lblPWD.Text=txtPwd.Text;
				string mySql = "Select USER_NAME,PWD,ORGANISATION from T32_CLIENT_LOGIN Where MOBILE='" + txtUserId.Text + "' and PWD='" + txtPwd.Text + "'";
				OracleCommand cmd = new OracleCommand(mySql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				if (!reader.HasRows)
				{
					conn.Close();
					Response.Write("<script language=JavaScript> alert('Invalid User Id / Password'); </script>");
				}
				else
				{


					conn.Close();
					txtUserId.Enabled = false;
					txtPwd.Enabled = false;
					btnLogin.Enabled = false;
					btnCPWD.Enabled = false;
					lblOTP.Visible = true;
					txtOTP.Visible = true;
					btnOTPProceed.Visible = true;
					Random random = new Random();
					string otp = Convert.ToString(random.Next(1000, 9999));
					send_Client_OTP(otp);

					conn.Open();
					OracleCommand myInsertCommand = new OracleCommand();
					string myInsertQuery = "INSERT INTO T37_CLIENT_LOGGIN_LOG (MOBILE,OTP,OTP_GEN_TIME,OTP_EXP_TIME) values(" + txtUserId.Text + ",'" + otp + "',TO_DATE('" + gen_time + "','DD/MM/YYYY-HH24:MI:SS'),TO_DATE('" + exp_time + "','DD/MM/YYYY-HH24:MI:SS'))";
					myInsertCommand.CommandText = myInsertQuery;
					myInsertCommand.Connection = conn;
					myInsertCommand.ExecuteNonQuery();
					conn.Close();
					client_email_otp(otp);


				}
			}
			catch (Exception ex)
			{
				string str = ex.Message.Replace("\n", "");
				if (str.Substring(1, 3) == "ORA")
				{ Response.Write("<script language=JavaScript> alert('Invalid User Id / Password'); </script>"); }
				else
				{ Response.Redirect(("Error_Form.aspx?err=" + str)); }

			}
			finally
			{
				conn.Close();
				conn.Dispose();
			}
		}
		void send_Client_OTP(string otp)
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			string sender = "RITES/QA";
			//string wVendor="",wVendMobile="";
			OracleCommand cmd = new OracleCommand();

			conn.Open();
			string message = otp + " is the One Time Password for verification of your login with RITES LTD- QA Division. Valid for 10 minutes. Please do not share with anyone." + "-" + sender;
			WebClient client = new WebClient();
			//string baseurl = "http://103.247.98.91/API/SendMsg.aspx?uname=20181896&pass=9eBWwFz9&send=RITESQ&dest="+txtUserId.Text+"&msg="+message+"&priority=1";
			//string baseurl = "http://sandeshlive.in/API/WebSMS/Http/v1.0a/index.php?username=2ritesltd&password=Ag@14rtd&sender=RITESQ&to="+txtUserId.Text+"&message="+message+"&reqid=1&format={json|text}&route_id=23";
			//string baseurl = "https://apps.sandeshlive.com/API/WebSMS/Http/v1.0a/index.php?userid=532&password=Aa4cHZ5QFfKJEVzI&sender=RITESQ&to="+txtUserId.Text+"&message="+message+"&reqid=1&format={json|text}&route_id=3";
			//string baseurl = "http://nimbusit.co.in/api/swsendSingle.asp?username=t1RitesLtd&password=104848267&sender=RITESQ&sendto="+txtUserId.Text+"&message="+message+"&entityID=1501484780000011007";				


			//string baseurl = "http://nimbusit.co.in/api/swsendSingle.asp?username=t1RitesLtd&password=104848267&sender=RITESI&sendto="+txtUserId.Text+"&entityID=1501628520000011823&templateID=1707161528969619943&message="+message;

			string baseurl = "http://apin.onex-aura.com/api/sms?key=QtPr681q&to=" + txtUserId.Text + "&from=RITESI&body=" + message + "&entityid=1501628520000011823&templateid=1707168743061977502";
			Stream data = client.OpenRead(baseurl);
			StreamReader smsreader = new StreamReader(data);
			string s = smsreader.ReadToEnd();
			data.Close();
			smsreader.Close();
			conn.Close();
			//conn.Dispose();

		}

		void client_email_otp(string otp)
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string mail_body = "";
				string client_mail = "";
				string mySql = "Select USER_NAME,EMAIL from T32_CLIENT_LOGIN Where MOBILE='" + txtUserId.Text + "' and PWD='" + txtPwd.Text + "'";
				OracleCommand cmd = new OracleCommand(mySql, conn);
				conn.Open();
				OracleDataReader readerB = cmd.ExecuteReader();
				while (readerB.Read())
				{
					client_mail = Convert.ToString(readerB["EMAIL"]).Trim();
					mail_body = "Dear Sir/Madam,<br><br> OTP for Client Login is: " + otp + ". This OTP is valid for 10 Mins only.<br><br> Thanks for using RITES Inspection Services. <br><br> RITES LTD.";
				}
				MailMessage mail2 = new MailMessage();
				mail2.To = client_mail;
				mail2.Bcc = "nrinspn@gmail.com";
				mail2.From = "nrinspn@gmail.com";
				mail2.Subject = "Your OTP For Client Login By RITES";
				mail2.BodyFormat = MailFormat.Html;
				mail2.Body = mail_body;
				mail2.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");   //basic authentication
																											//			SmtpMail.SmtpServer= "127.0.0.1";  //your real server goes here
				SmtpMail.SmtpServer = "10.60.50.81";
				mail2.Priority = MailPriority.High;
				SmtpMail.Send(mail2);
				conn.Close();
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				//				Response.Write(ex);
			}
			finally
			{
				conn.Close();
				conn.Dispose();
			}
		}

		protected void btnCPWD_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Change_Client_Pwd_Form.aspx");
		}

		protected void btnOTPProceed_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				conn.Open();
				OracleCommand cmd11 = new OracleCommand("Select to_char(sysdate,'DD/MM/YYYY-HH24:MI:SS') from dual", conn);
				string ss = Convert.ToString(cmd11.ExecuteScalar());


				string mySql = "Select USER_NAME,PWD,ORGANISATION,ORGN_TYPE from T32_CLIENT_LOGIN T32, T37_CLIENT_LOGGIN_LOG T37 Where T32.MOBILE=T37.MOBILE AND T37.MOBILE='" + txtUserId.Text + "' AND OTP='" + txtOTP.Text + "' and TO_CHAR(OTP_GEN_TIME,'dd/mm/yyyy-HH24:MI:SS')='" + lblGen_Time.Text + "' AND LOGGIN_TIME IS NULL AND T37.STATUS IS NULL AND (to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') BETWEEN OTP_GEN_TIME AND OTP_EXP_TIME)";
				OracleCommand cmd = new OracleCommand(mySql, conn);

				OracleDataReader reader = cmd.ExecuteReader();
				if (!reader.HasRows)
				{
					conn.Close();
					Response.Write("<script language=JavaScript> alert('Invalid OTP/OTP Expired'); </script>");
				}
				else
				{
					reader.Read();
					Session["CLIENT"] = Convert.ToString(reader["USER_NAME"]);
					Session["ORGN"] = Convert.ToString(reader["ORGANISATION"]);
					Session["ORGN_TYPE"] = Convert.ToString(reader["ORGN_TYPE"]);


					OracleCommand myUpdateCommand = new OracleCommand();
					string myUpdateQuery = "Update T37_CLIENT_LOGGIN_LOG  set LOGGIN_TIME=TO_DATE('" + ss + "','DD/MM/YYYY-HH24:MI:SS'), STATUS = 'A' where MOBILE=" + txtUserId.Text + " AND OTP='" + txtOTP.Text + "' AND TO_CHAR(OTP_GEN_TIME,'dd/mm/yyyy-HH24:MI:SS')='" + lblGen_Time.Text + "'";
					myUpdateCommand.CommandText = myUpdateQuery;
					myUpdateCommand.Connection = conn;
					myUpdateCommand.ExecuteNonQuery();
					conn.Close();


				}
			}
			catch (Exception ex)
			{
				string str = ex.Message.Replace("\n", "");
				if (str.Substring(1, 3) == "ORA")
				{ Response.Write("<script language=JavaScript> alert('Invalid User Id / Password'); </script>"); }
				else
				{ Response.Redirect(("Error_Form.aspx?err=" + str)); }

			}
			finally
			{
				conn.Close();
				conn.Dispose();
			}
			Response.Write("<script language=JavaScript>var oWin= window.open('Client_MainForm.aspx','', 'fullscreen=yes, scrollbars=yes');");
			Response.Write("if (oWin==null || typeof(oWin)=='undefined') alert('System has been blocked by POP-UP BLOCKER!!!\\nPlease disable the POP-UP BLOCKER and try again or Please contact your system administrator.');</script>");
			Response.Write("<script language='Javascript'>window.opener='x';window.close();</script>");
		}
	}
}