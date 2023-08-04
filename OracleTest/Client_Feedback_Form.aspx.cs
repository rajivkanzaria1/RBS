using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Client_Feedback_Form
{
	public partial class Client_Feedback_Form : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.RadioButton RadioButton1;
		protected System.Web.UI.WebControls.RadioButton RadioButton2;
		protected System.Web.UI.WebControls.RadioButton RadioButton3;
		protected System.Web.UI.WebControls.RadioButton RadioButton4;
		protected System.Web.UI.WebControls.RadioButton Radiobutton13;
		protected System.Web.UI.WebControls.RadioButton Radiobutton14;
		protected System.Web.UI.WebControls.RadioButton Radiobutton15;
		protected System.Web.UI.WebControls.RadioButton Radiobutton17;
		protected System.Web.UI.WebControls.RadioButton Radiobutton18;
		protected System.Web.UI.WebControls.RadioButton Radiobutton19;
		protected System.Web.UI.WebControls.RadioButton Radiobutton21;
		protected System.Web.UI.WebControls.RadioButton Radiobutton22;
		protected System.Web.UI.WebControls.RadioButton Radiobutton23;
		protected System.Web.UI.WebControls.RadioButton Radiobutton25;
		protected System.Web.UI.WebControls.RadioButton Radiobutton26;
		protected System.Web.UI.WebControls.RadioButton Radiobutton27;
		protected System.Web.UI.WebControls.RadioButton Radiobutton29;
		protected System.Web.UI.WebControls.RadioButton Radiobutton30;
		protected System.Web.UI.WebControls.RadioButton Radiobutton31;
		protected System.Web.UI.WebControls.RadioButton Radiobutton33;
		protected System.Web.UI.WebControls.RadioButton Radiobutton34;
		protected System.Web.UI.WebControls.RadioButton Radiobutton35;
		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);


		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");

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



		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}


		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				int[] field_marks = new int[11];
				if (rdbBA1.Checked == true)
				{
					field_marks[0] = 1;
				}
				else if (rdbG1.Checked == true)
				{
					field_marks[0] = 2;
				}
				else if (rdbVG1.Checked == true)
				{
					field_marks[0] = 3;
				}
				else if (rdbEX1.Checked == true)
				{
					field_marks[0] = 4;
				}

				if (rdbBA2.Checked == true)
				{
					field_marks[1] = 1;
				}
				else if (rdbG2.Checked == true)
				{
					field_marks[1] = 2;
				}
				else if (rdbVG2.Checked == true)
				{
					field_marks[1] = 3;
				}
				else if (rdbEX2.Checked == true)
				{
					field_marks[1] = 4;
				}

				if (rdbBA3.Checked == true)
				{
					field_marks[2] = 1;
				}
				else if (rdbG3.Checked == true)
				{
					field_marks[2] = 2;
				}
				else if (rdbVG3.Checked == true)
				{
					field_marks[2] = 3;
				}
				else if (rdbEX3.Checked == true)
				{
					field_marks[2] = 4;
				}

				if (rdbBA4.Checked == true)
				{
					field_marks[3] = 1;
				}
				else if (rdbG4.Checked == true)
				{
					field_marks[3] = 2;
				}
				else if (rdbVG4.Checked == true)
				{
					field_marks[3] = 3;
				}
				else if (rdbEX4.Checked == true)
				{
					field_marks[3] = 4;
				}

				if (rdbBA5.Checked == true)
				{
					field_marks[4] = 1;
				}
				else if (rdbG5.Checked == true)
				{
					field_marks[4] = 2;
				}
				else if (rdbVG5.Checked == true)
				{
					field_marks[4] = 3;
				}
				else if (rdbEX5.Checked == true)
				{
					field_marks[4] = 4;
				}

				if (rdbBA6.Checked == true)
				{
					field_marks[5] = 1;
				}
				else if (rdbG6.Checked == true)
				{
					field_marks[5] = 2;
				}
				else if (rdbVG6.Checked == true)
				{
					field_marks[5] = 3;
				}
				else if (rdbEX6.Checked == true)
				{
					field_marks[5] = 4;
				}

				if (rdbBA7.Checked == true)
				{
					field_marks[6] = 1;
				}
				else if (rdbG7.Checked == true)
				{
					field_marks[6] = 2;
				}
				else if (rdbVG7.Checked == true)
				{
					field_marks[6] = 3;
				}
				else if (rdbEX7.Checked == true)
				{
					field_marks[6] = 4;
				}

				if (rdbBA8.Checked == true)
				{
					field_marks[7] = 1;
				}
				else if (rdbG8.Checked == true)
				{
					field_marks[7] = 2;
				}
				else if (rdbVG8.Checked == true)
				{
					field_marks[7] = 3;
				}
				else if (rdbEX8.Checked == true)
				{
					field_marks[7] = 4;
				}

				if (rdbBA9.Checked == true)
				{
					field_marks[8] = 1;
				}
				else if (rdbG9.Checked == true)
				{
					field_marks[8] = 2;
				}
				else if (rdbVG9.Checked == true)
				{
					field_marks[8] = 3;
				}
				else if (rdbEX9.Checked == true)
				{
					field_marks[8] = 4;
				}

				if (rdbBA10.Checked == true)
				{
					field_marks[9] = 1;
				}
				else if (rdbG10.Checked == true)
				{
					field_marks[9] = 2;
				}
				else if (rdbVG10.Checked == true)
				{
					field_marks[9] = 3;
				}
				else if (rdbEX10.Checked == true)
				{
					field_marks[9] = 4;
				}

				if (rdbBA11.Checked == true)
				{
					field_marks[10] = 1;
				}
				else if (rdbG11.Checked == true)
				{
					field_marks[10] = 2;
				}
				else if (rdbVG11.Checked == true)
				{
					field_marks[10] = 3;
				}
				else if (rdbEX11.Checked == true)
				{
					field_marks[10] = 4;
				}
				if (lstRegionCd.SelectedValue != "")
				{
					string myInsertQuery = "INSERT INTO CLIENT_FEEDBACK (CLIENT,OFF_NAME,MOBILE,EMAIL,REGION_CODE,FIELD_1,FIELD_2,FIELD_3,FIELD_4,FIELD_5,FIELD_6,FIELD_7,FIELD_8,FIELD_9,FIELD_10,FIELD_11,FIELD_12)values('" + txtClient.Text.Trim() + "','" + txtOffName.Text.Trim() + "'," + txtMobile.Text.Trim() + ",'" + txtEmail.Text.Trim() + "','" + lstRegionCd.SelectedValue + "'," + field_marks[0] + "," + field_marks[1] + "," + field_marks[2] + "," + field_marks[3] + "," + field_marks[4] + "," + field_marks[5] + "," + field_marks[6] + "," + field_marks[7] + "," + field_marks[8] + "," + field_marks[9] + "," + field_marks[10] + ",'" + txtSuggestions.Text.Trim() + "')";
					OracleCommand myInsertCommand = new OracleCommand();
					conn.Open();
					myInsertCommand.CommandText = myInsertQuery;
					myInsertCommand.Connection = conn;
					myInsertCommand.ExecuteNonQuery();
					conn.Close();

					string sender_email = "";
					if (lstRegionCd.SelectedValue == "N")
					{
						sender_email = "nrinspn@rites.com";
					}
					else if (lstRegionCd.SelectedValue == "W")
					{
						sender_email = "wrinspn@rites.com";
					}
					else if (lstRegionCd.SelectedValue == "E")
					{
						sender_email = "erinspn@rites.com";
					}
					else if (lstRegionCd.SelectedValue == "S")
					{
						sender_email = "srinspn@rites.com";
					}
					else if (lstRegionCd.SelectedValue == "Q")
					{
						sender_email = "qa_feedback@rites.com";
					}
					else if (lstRegionCd.SelectedValue == "C")
					{
						sender_email = "crinspn_feedback@rites.com";
					}

					if (txtEmail.Text.Trim() != "")
					{
						MailMessage mail = new MailMessage();
						mail.To = txtEmail.Text.Trim();
						mail.Cc = "nrinspn@gmail.com";
						//mail.From = sender_email;
						mail.From = "nrinspn@gmail.com";
						mail.Subject = "Your Feedback Response - RITES LTD";
						mail.Body = "Thank You Sir/Mam for your feedback, we will work as the suggestions given by you to improve our services. \n\n RITES LTD \n QA Division";
						mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
						SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
						mail.Priority = MailPriority.High;
						SmtpMail.Send(mail);
					}
					DisplayAlert("Your FeedBack is sent to QA Division, RITES LTD");
				}
				else
				{
					DisplayAlert("Region for which Feedback to be submitted Cannot be Left Blank!!!");
				}

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				if (str1.Substring(0, 9).Equals("ORA-00001"))
				{ DisplayAlert("Entry Already Exist For Given Mobile and Region!!!"); }
				else
				{ Response.Redirect(("Error_Form.aspx?err=" + str1)); }
			}
			finally
			{
				conn.Close();
				conn.Dispose();
			}
		}
	}
}