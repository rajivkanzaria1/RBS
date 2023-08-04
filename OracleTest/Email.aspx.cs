using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Email
{
	public partial class Email : System.Web.UI.Page
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSubmit.Attributes.Add("OnClick", "JavaScript:validate();");
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

		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{


			MailMessage mail = new MailMessage();
			if (lstRegionCd.SelectedValue == "N")
			{
				mail.To = "nrinspn.feedback@rites.com";
				mail.Cc = "sbu.ninsp@rites.com;qa_feedback@rites.com;";
			}
			else if (lstRegionCd.SelectedValue == "S")
			{
				mail.To = "srinspn_feedback@rites.com";
				mail.Cc = "sbu.sinsp@rites.com;qa_feedback@rites.com;";
			}
			else if (lstRegionCd.SelectedValue == "W")
			{
				mail.To = "wrinspn_feedback@rites.com";
				mail.Cc = "sbu.winsp@rites.com;qa_feedback@rites.com;";
			}
			else if (lstRegionCd.SelectedValue == "E")
			{
				mail.To = "erinspn_feedback@rites.com";
				mail.Cc = "sbu.einsp@rites.com;qa_feedback@rites.com;";
			}
			else if (lstRegionCd.SelectedValue == "C")
			{
				mail.To = "crinspn_feedback@rites.com";
				mail.Cc = "sbu.cinsp@rites.com;qa_feedback@rites.com;";
			}
			else if (lstRegionCd.SelectedValue == "Q")
			{
				mail.To = "qa_feedback@rites.com";
				mail.Cc = "sandeepmehra@rites.com;qa_feedback@rites.com;";
			}
			if (lstRegionCd.SelectedValue != "" || txtFrom.Text != "" || txtNameofComp.Text.Trim() == "" || txtMobofComp.Text.Trim() == "")
			{
				try
				{



					//mail.To = txtTo.Text;
					mail.From = txtFrom.Text;
					mail.Subject = txtSubject.Text;
					mail.Body = txtBody.Text + "\n\n Name: " + txtNameofComp.Text.Trim() + "\n\n Mobile No. : " + txtMobofComp.Text.Trim();
					mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
																												//			mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "agg.sumit@gmail.com"); //set your username here
																												//			mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "ourhome");	//set your password here


					SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
					mail.Priority = MailPriority.High;
					//mail.Attachments.Add(File1);
					SmtpMail.Send(mail);
					litStatus.Text = "Message Sent Sucessfully, We will respond you shortly.";
					DisplayAlert("Message Sent Sucessfully, We will respond you shortly.!!! ");
					txtFrom.Text = "";
					lstRegionCd.SelectedValue = "";
					txtSubject.Text = "";
					txtBody.Text = "";
					txtNameofComp.Text = "";
					txtMobofComp.Text = "";

				}
				catch (Exception ex)
				{
					string str;
					string str1;
					if (lstRegionCd.SelectedValue == "N")
					{
						str1 = "Northern Region: nrinspn.feedback@rites.com";
					}
					else if (lstRegionCd.SelectedValue == "E")
					{
						str1 = "Eastern Region: erinspn_feedback@rites.com";
					}
					else if (lstRegionCd.SelectedValue == "W")
					{
						str1 = "Western Region: wrinspn_feedback@rites.com";
					}
					else if (lstRegionCd.SelectedValue == "S")
					{
						str1 = "Southern Region: srinspn_feedback@rites.com";
					}
					else
					{
						str1 = "QA Division: qa_feedback@rites.com";
					}

					str = ex.ToString() + "Mail Cannot be sent right now, Kindly Email us at " + str1;
					Response.Write(str);
				}
			}
			else
			{
				Response.Write("<script language=JavaScript> alert('You Cannot Leave To Region, From Email,  Name & Mobile No. Blank!!!'); </script>");
			}


		}
	}
}