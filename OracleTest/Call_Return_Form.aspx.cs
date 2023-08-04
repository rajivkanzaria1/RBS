using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Call_Return_Form
{
	public partial class Call_Return_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		int ecode = 0;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnFCList.Attributes.Add("OnClick", "JavaScript:validate1();");
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			if (!(IsPostBack))
			{

				ListItem lst = new ListItem();
				lst.Text = "";
				lst.Value = "";
				lstClientType.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "Railways";
				lst.Value = "R";
				lstClientType.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "Private";
				lst.Value = "P";
				lstClientType.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "PSU";
				lst.Value = "U";
				lstClientType.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "State Govt.";
				lst.Value = "S";
				lstClientType.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "Foreign Railways";
				lst.Value = "F";
				lstClientType.Items.Add(lst);


				ddlVender.Visible = false;
				Label_Return_No.Visible = false;
				lblReturn_No.Visible = false;


				conn1.Open();
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual", conn1);
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				conn1.Close();
				conn1.Dispose();
				lblReturn_DT.Text = ss;

				fill_Rly();
			}
		}
		public void fill_Rly()
		{
			lstBPO_Rly.Items.Clear();
			DataSet dsP = new DataSet();
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString); ;
			try
			{
				string str = "";
				if (lstClientType.SelectedValue == "R")
				{
					str = "Select RLY_CD from T91_RAILWAYS Order by RLY_CD";
				}
				else
				{
					str = "Select distinct(upper(trim(BPO_RLY))) RLY_CD from T12_BILL_PAYING_OFFICER WHERE BPO_TYPE='" + lstClientType.SelectedValue + "' Order by RLY_CD";
				}
				OracleDataAdapter da = new OracleDataAdapter(str, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str, conn1);
				ListItem lst;
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				conn1.Close();
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					lst = new ListItem();
					lst.Text = dsP.Tables[0].Rows[i]["RLY_CD"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["RLY_CD"].ToString();
					lstBPO_Rly.Items.Add(lst);
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
		int fill_vendor(string str2)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			ddlVender.Items.Clear();
			DataSet dsP = new DataSet();
			//string str1 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and (trim(upper(VEND_CD))=upper('"+vend.Trim()+"') or trim(upper(VEND_NAME)) LIKE upper('"+vend.Trim()+"%')) and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME"; 
			OracleDataAdapter da = new OracleDataAdapter(str2, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str2, conn1);
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
					ddlVender.Items.Add(lst);
				}
				ddlVender.Visible = true;
				ddlVender.SelectedIndex = 0;
				lblVendor.Text = ddlVender.SelectedItem.Text;
				//rbs.SetFocus(ddlVender);
				ecode = 2;
				return (ecode);

			}

		}

		void vendor_status(String ven)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string vend;
				conn1.Open();
				string s = "select VEND_STATUS,to_char(VEND_STATUS_DT_FR,'dd/mm/yyyy')VEND_STATUS_FR,to_char(VEND_STATUS_DT_TO,'dd/mm/yyyy')VEND_STATUS_TO from T05_VENDOR where  VEND_CD='" + ddlVender.SelectedValue + "'";
				OracleCommand cmd = new OracleCommand(s, conn1);
				OracleDataReader dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					vend = Convert.ToString(dr["VEND_STATUS"]);
					if (vend == "B")
					{
						DisplayAlert("This Vendor is Banned/Blacklisted From  " + Convert.ToString(dr["VEND_STATUS_FR"]) + " To " + Convert.ToString(dr["VEND_STATUS_TO"]));
						txtVend.Text = "";
						ddlVender.Visible = false;
					}
					else
					{
						txtVend.Text = ddlVender.SelectedValue;
					}
				}
				dr.Close();
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
		protected void btnFCList_Click(object sender, System.EventArgs e)
		{
			ddlVender.Visible = true;

			try
			{
				if (Convert.ToInt32(txtVend.Text) >= 1 && Convert.ToInt32(txtVend.Text) <= 999999)
				{

					string str1 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and trim(VEND_CD)=" + txtVend.Text.Trim() + " and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME";
					int a = fill_vendor(str1);
					if (a == 1)
					{
						ddlVender.Visible = false;
						DisplayAlert("No Vendor Found!!!");
						rbs.SetFocus(txtVend);
					}
					else if (a == 2)
					{
						vendor_status(ddlVender.SelectedValue);
						rbs.SetFocus(ddlVender);
						getvend_info();
					}
				}
				else
				{
					DisplayAlert("Invalid Vendor Code!!!");
					ddlVender.Items.Clear();
					ddlVender.Visible = false;
				}


			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = "Input string was not in a correct format.";
				if (str.Equals(str1))
				{
					string str2 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and trim(upper(VEND_NAME)) LIKE upper('" + txtVend.Text.Trim() + "%') and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME";
					int a = fill_vendor(str2);
					if (a == 1)
					{
						ddlVender.Visible = false;
						DisplayAlert("No Vendor Found!!!");
						rbs.SetFocus(txtVend);
					}
					else if (a == 2)
					{
						vendor_status(ddlVender.SelectedValue);
						rbs.SetFocus(ddlVender);
						getvend_info();
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
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		protected void lstClientType1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fill_Rly();
			rbs.SetFocus(lstBPO_Rly);
		}
		void getvend_info()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			lblVendor.Text = ddlVender.SelectedItem.Text;
			try
			{
				string sql = "Select VEND_EMAIL, NVL2(VEND_CONTACT_TEL_2,VEND_CONTACT_TEL_1||','||VEND_CONTACT_TEL_2,VEND_CONTACT_TEL_1) VEND_CONTACT from T05_VENDOR where VEND_CD=" + ddlVender.SelectedValue;
				OracleCommand cmd = new OracleCommand(sql, conn1);
				conn1.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					txtVend_Email.Text = reader["VEND_EMAIL"].ToString();
					txtVend_Contact_NO.Text = reader["VEND_CONTACT"].ToString();
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

		protected void ddlVender_SelectedIndexChanged(object sender, System.EventArgs e)
		{

			getvend_info();
		}
		int[] reasons()
		{
			int[] chk = new int[11];
			int j = 0;
			for (int i = 0; i < 1; i++)
			{
				if (chk1.Checked == true)
				{
					chk[j] = Convert.ToInt32(chk1.Text.Substring(0, 2));
					j++;
				}
				if (chk2.Checked == true)
				{
					chk[j] = Convert.ToInt32(chk2.Text.Substring(0, 2));
					j++;
				}
				if (chk3.Checked == true)
				{
					chk[j] = Convert.ToInt32(chk3.Text.Substring(0, 2));
					j++;
				}
				if (chk4.Checked == true)
				{
					chk[j] = Convert.ToInt32(chk4.Text.Substring(0, 2));
					j++;
				}
				if (chk5.Checked == true)
				{
					chk[j] = Convert.ToInt32(chk5.Text.Substring(0, 2));
					j++;
				}
				if (chk6.Checked == true)
				{
					chk[j] = Convert.ToInt32(chk6.Text.Substring(0, 2));
					j++;
				}
				if (chk7.Checked == true)
				{
					chk[j] = Convert.ToInt32(chk7.Text.Substring(0, 2));
					j++;
				}
				if (chk8.Checked == true)
				{
					chk[j] = Convert.ToInt32(chk8.Text.Substring(0, 2));
					j++;
				}
				if (chk9.Checked == true)
				{
					chk[j] = Convert.ToInt32(chk9.Text.Substring(0, 2));
					j++;
				}

			}
			return (chk);
		}

		private string generate_Return_NO()
		{
			string wRETURN_NO = "";
			try
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

				OracleCommand cmd = new OracleCommand("GENERATE_CALL_RETURN_NO", conn1);
				cmd.CommandType = CommandType.StoredProcedure;
				conn1.Open();

				OracleParameter prm1 = new OracleParameter("IN_REGION_CD", OracleDbType.Char);
				prm1.Direction = ParameterDirection.Input;
				prm1.Value = Session["Region"].ToString();
				cmd.Parameters.Add(prm1);

				OracleParameter prm2 = new OracleParameter("IN_RETURN_DT", OracleDbType.Char);
				prm2.Direction = ParameterDirection.Input;
				prm2.Value = Convert.ToString(lblReturn_DT.Text);
				cmd.Parameters.Add(prm2);

				OracleParameter prm3 = new OracleParameter("OUT_RETURN_NO", OracleDbType.Char, 10);
				prm3.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(prm3);

				OracleParameter prm4 = new OracleParameter("OUT_ERR_CD", OracleDbType.Int32);
				prm4.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(prm4);

				cmd.ExecuteNonQuery();

				if (Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value) == -1)
				{
					wRETURN_NO = "-1";
				}
				else
				{
					wRETURN_NO = Convert.ToString(cmd.Parameters["OUT_RETURN_NO"].Value);
				}
				conn1.Close();
				return (wRETURN_NO);
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

		protected void btnSave_Click(object sender, System.EventArgs e)
		{

			string RETURN_NO = generate_Return_NO();
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
			string wCDT = Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();


			try
			{


				int[] chk1 = reasons();

				//					if (Action == "A") 
				//					{
				if (RETURN_NO == "-1")
				{
					DisplayAlert("Call Return Details not available");
				}
				else
				{
					string myInsertQuery = "INSERT INTO T43_CALL_RETURN values('" + RETURN_NO + "', to_date('" + lblReturn_DT.Text + "','dd/mm/yyyy'), " + ddlVender.SelectedValue + ",'" + txtVend_Email.Text.Trim() + "','" + txtVend_Contact_NO.Text.Trim() + "','" + lstClientType.SelectedValue + "','" + lstBPO_Rly.SelectedValue + "','" + txtCallNO.Text + "',to_date('" + txtCall_Lett_DT.Text + "','dd/mm/yyyy'),to_date('" + txtDatePOrites.Text + "','dd/mm/yyyy')," + chk1[0] + "," + chk1[1] + "," + chk1[2] + "," + chk1[3] + "," + chk1[4] + "," + chk1[5] + "," + chk1[6] + "," + chk1[7] + "," + chk1[8] + ",'" + txtRRemarks.Text + "','" + Session["Uname"] + "',to_date('" + wCDT + "','dd/mm/yyyy-HH24:MI:SS'))";
					OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
					myInsertCommand.Connection = conn1;
					conn1.Open();
					myInsertCommand.ExecuteNonQuery();
					conn1.Close();
					DisplayAlert("Your Record is Saved!!!");
					lblReturn_No.Visible = true;
					lblReturn_No.Text = RETURN_NO;
					Label_Return_No.Visible = true;
					btnSave.Visible = false;
					send_email();
				}
				//					} 
				//					else if(Action=="M")
				//					{ 
				//						string myUpdateQuery = "Update T19_CALL_CANCEL set CANCEL_DATE=to_date('"+txtCCancelDT.Text+"','dd/mm/yyyy'),CANCEL_CD_1="+chk1[0]+",CANCEL_CD_2="+chk1[1]+",CANCEL_CD_3="+chk1[2]+",CANCEL_CD_4="+chk1[3]+",CANCEL_CD_5="+chk1[4]+",CANCEL_CD_6="+chk1[5]+",CANCEL_CD_7="+chk1[6]+",CANCEL_CD_8="+chk1[7]+",CANCEL_CD_9="+chk1[8]+",CANCEL_CD_10="+chk1[9]+",CANCEL_CD_11="+chk1[10]+",CANCEL_DESC ='" + txtCdesc.Text + "',USER_ID='"+Session["Uname"]+"',DATETIME=to_date('"+wCDT+"','dd/mm/yyyy-HH24:MI:SS'),DOCS_SUBMITTED='"+lstDocRec.SelectedValue+"' where CASE_NO='"+txtCaseNo.Text+"' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and CALL_SNO="+lblCSNO.Text; 
				//						OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery); 
				//						myUpdateCommand.Connection = conn1; 
				//						conn1.Open();
				//						myUpdateCommand.ExecuteNonQuery(); 
				//						conn1.Close();
				//						btnDelete.Visible=true;
				//						conn1.Close(); 
				//						DisplayAlert("Your Record is Modified!!!");
				//					}



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

		string get_cancel_reasons()
		{
			string reason = "";
			if (chk1.Checked == true)
			{
				reason = reason + "\n=> " + chk1.Text.Substring(5, chk1.Text.Length - 5) + "<BR>";
			}
			if (chk2.Checked == true)
			{
				reason = reason + "\n=> " + chk2.Text.Substring(5, chk2.Text.Length - 5) + "<BR>";
			}
			if (chk3.Checked == true)
			{
				reason = reason + "\n=> " + chk3.Text.Substring(5, chk3.Text.Length - 5) + "<BR>";
			}
			if (chk4.Checked == true)
			{
				reason = reason + "\n=> " + chk4.Text.Substring(5, chk4.Text.Length - 5) + "<BR>";
			}
			if (chk5.Checked == true)
			{
				reason = reason + "\n=> " + chk5.Text.Substring(5, chk5.Text.Length - 5) + "<BR>";
			}
			if (chk6.Checked == true)
			{
				reason = reason + "\n=> " + chk6.Text.Substring(5, chk6.Text.Length - 5) + "<BR>";
			}
			if (chk7.Checked == true)
			{
				reason = reason + "\n=> " + chk7.Text.Substring(5, chk7.Text.Length - 5) + "<BR>";
			}
			if (chk8.Checked == true)
			{
				reason = reason + "\n=> " + chk8.Text.Substring(5, chk8.Text.Length - 5) + "<BR>";
			}
			if (chk9.Checked == true)
			{
				reason = reason + "\n=> " + chk9.Text + " (" + txtRRemarks.Text + ")" + "<BR>";
			}
			return (reason);
		}
		void send_email()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string wRegion = "";

				string sender = "";
				OracleCommand cmd_vend = new OracleCommand("Select T05.VEND_CD,T05.VEND_NAME,NVL2(T05.VEND_ADD2,T05.VEND_ADD1||'/'||T05.VEND_ADD2,T05.VEND_ADD1) VEND_ADDRESS,T03.CITY VEND_CITY, T05.VEND_EMAIL from T05_VENDOR T05, T03_CITY T03 where T05.VEND_CITY_CD=T03.CITY_CD and T05.VEND_CD=" + ddlVender.SelectedValue, conn1);
				conn1.Open();
				OracleDataReader reader = cmd_vend.ExecuteReader();
				string vend_cd = "", vend_name = "", vend_email = "", vend_city = "", vend_add = "";
				while (reader.Read())
				{
					vend_cd = Convert.ToString(reader["VEND_CD"]);
					vend_name = Convert.ToString(reader["VEND_NAME"]);
					vend_add = Convert.ToString(reader["VEND_ADDRESS"]);
					vend_city = Convert.ToString(reader["VEND_CITY"]);
					vend_email = Convert.ToString(reader["VEND_EMAIL"]);
					//					rly_cd=Convert.ToString(reader["RLY_CD"]);
					if (Session["Region"].ToString() == "N") { wRegion = "NORTHERN REGION \n 12th FLOOR,CORE-II,SCOPE MINAR,LAXMI NAGAR, DELHI - 110092 \n Phone : +918800018691-95 \n Fax : 011-22024665"; sender = "nrinspn@rites.com"; }
					else if (Session["Region"].ToString() == "S") { wRegion = "SOUTHERN REGION \n CTS BUILDING - 2ND FLOOR, BSNL COMPLEX, NO. 16, GREAMS ROAD,  CHENNAI - 600 006 \n Phone : 044-28292807/044- 28292817 \n Fax : 044-28290359"; sender = "srinspn@rites.com"; }
					else if (Session["Region"].ToString() == "E") { wRegion = "EASTERN REGION \n CENTRAL STATION BUILDING(METRO), 56, C.R. AVENUE,3rd FLOOR,KOLKATA-700 012  \n Fax : 033-22348704"; sender = "erinspn@rites.com"; }
					else if (Session["Region"].ToString() == "W") { wRegion = "WESTERN REGION \n 5TH FLOOR, REGENT CHAMBER, ABOVE STATUS RESTAURANT,NARIMAN POINT,MUMBAI-400021 \n Phone : 022-68943400/68943445 <BR>"; sender = "wrinspn@rites.com"; }
					else if (Session["Region"].ToString() == "C") { wRegion = "Central Region"; }
				}
				conn1.Close();

				string can_reasons = get_cancel_reasons();

				string call_letter_dt = "", call_letter_no = "";
				if (txtCall_Lett_DT.Text.Trim() == "")
				{
					call_letter_dt = "NIL";
				}
				else
				{
					call_letter_dt = txtCall_Lett_DT.Text.Trim();
				}

				if (txtCallNO.Text.Trim() == "")
				{
					call_letter_no = "NIL";
				}
				else
				{
					call_letter_no = txtCallNO.Text.Trim();
				}

				string mail_body = vend_name + ",\n" + vend_add + ",\n" + vend_city + ",\n\n Dear Sir/Madam, \n In reference to Your inspection Call Letter no. " + call_letter_no + " Dated:  " + call_letter_dt + " was received in this office on " + txtDatePOrites.Text + ". \n Your call is being returned back to you due to following reasons(s):- \n" + can_reasons + "\n.<b> Please resubmit you Inspection call letter after rectifying above mentioned reasons. \n\n Thanks for using RITES Inspection Services. \n NATIONAL INSPECTION HELP LINE NUMBER : 1800 425 7000 (TOLL FREE). \n\n" + wRegion + ".";


				if (vend_email.Trim() == txtVend_Email.Text.Trim())
				{
					MailMessage mail = new MailMessage();
					mail.To = vend_email;
					mail.Bcc = "nrinspn@gmail.com";
					mail.From = sender;
					mail.Subject = "Call Letter Return";
					mail.Body = mail_body;
					mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
					SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
					mail.Priority = MailPriority.High;
					SmtpMail.Send(mail);
				}
				else if (vend_email.Trim() != txtVend_Email.Text.Trim() && txtVend_Email.Text.Trim() != "")
				{
					MailMessage mail1 = new MailMessage();
					mail1.To = vend_email;
					mail1.Cc = txtVend_Email.Text;
					mail1.Bcc = "nrinspn@gmail.com";
					mail1.From = sender;
					mail1.Subject = "Call Letter Return";
					mail1.Body = mail_body;
					mail1.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");   //basic authentication
					SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
					mail1.Priority = MailPriority.High;
					SmtpMail.Send(mail1);

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
		protected void Button1_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Call_Return_Form.aspx");
		}
	}
}