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

namespace RBS.DEO_Vendor_PurchesOrder1_Form
{
	public partial class DEO_Vendor_PurchesOrder1_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected System.Web.UI.WebControls.TextBox txtHQuater;
		protected System.Web.UI.WebControls.TextBox txtRailProUnit;
		protected System.Web.UI.HtmlControls.HtmlGenericControl repdiv;

		OracleDataAdapter da1 = new OracleDataAdapter();
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if (!(IsPostBack))
			{
				fillgrid();
				if (Session["Role_CD"].ToString() == "4")
				{

					DgPO1.Columns[0].Visible = false;

				}
				DgPO1.Columns[10].Visible = false;
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
			this.DgPO1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DgPO1_ItemDataBound);

		}
		#endregion

		void fillgrid()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			try
			{
				string str1 = "select m.CASE_NO,m.REAL_CASE_NO,m.PO_NO,to_char(m.PO_DT,'dd/mm/yyyy')PO_DT,to_char(m.RECV_DT,'dd/mm/yyyy')RECV_DT, decode(m.RLY_NONRLY,'R','Railway','P','Private','S','State Government','F','Foreign Railways','U','PSU') RLY_NONRLY, m.RLY_CD,(v.VEND_NAME||'('||NVL2(t.LOCATION,t.LOCATION||' : '||t.CITY,t.CITY)||')')VEND_NAME,m.REMARKS,'Vendor/PO/'||m.CASE_NO||'.pdf' PO_DOC from T80_PO_MASTER m,T05_VENDOR v,T03_CITY t where m.VEND_CD=v.VEND_CD and v.VEND_CITY_CD=t.CITY_CD And m.REGION_CODE='" + Session["Region"].ToString() + "' and RECV_DT>'01-DEC-2016' and m.REAL_CASE_NO is null";


				string str2 = str1 + " ORDER BY m.DATETIME DESC";

				OracleDataAdapter da1 = new OracleDataAdapter(str2, conn1);
				DataSet dsP1 = new DataSet();
				OracleCommand myOracleCommand1 = new OracleCommand(str2, conn1);
				conn1.Open();
				da1.SelectCommand = myOracleCommand1;
				da1.Fill(dsP1, "Table");
				//OracleDataAdapter da1 = new OracleDataAdapter(str1, conn1); 
				if (dsP1.Tables[0].Rows.Count == 0)
				{
					DgPO1.Visible = false;
					//repdiv.Visible=false;
					//Label6.Visible =true;
					//						throw new System.Exception("No PurchaseOrder found. !!! ");
					lblError.Visible = true;
					DgPO1.Visible = false;

				}
				else
				{
					DgPO1.DataSource = dsP1;
					DgPO1.DataBind();
					DgPO1.Visible = true;
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



		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("MainForm.aspx");
		}
		public void DgPO1_Edit(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DgPO1.EditItemIndex = e.Item.ItemIndex;
			DgPO1.Columns[10].Visible = true;
			fillgrid();

		}

		public void DgPO1_Cancel(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DgPO1.EditItemIndex = -1;
			DgPO1.Columns[10].Visible = false;
			fillgrid();
		}


		public void DgPO1_Update(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			string refno = Convert.ToString(e.Item.Cells[2].Text);
			string v_po_no = Convert.ToString(e.Item.Cells[3].Text);
			string v_po_dt = Convert.ToString(e.Item.Cells[4].Text);
			string v_rly_cd = Convert.ToString(e.Item.Cells[7].Text);

			string po_no = "";
			string po_dt = "";
			string rly_cd = "";
			string realCSNO = "";
			if ((e.Item.FindControl("txtRealCSNO") as TextBox).Text.Trim() != "")
			{
				realCSNO = Convert.ToString((e.Item.FindControl("txtRealCSNO") as TextBox).Text.Trim());

			}
			try
			{
				conn1.Open();
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				conn1.Close();

				if (realCSNO.Length == 9)
				{
					string str = "select PO_NO,to_char(PO_DT,'dd/mm/yyyy') PO_DATE,RLY_CD from T13_PO_MASTER where CASE_NO='" + realCSNO + "'";
					OracleCommand myOracleCommand = new OracleCommand(str, conn1);
					conn1.Open();
					OracleDataReader reader = myOracleCommand.ExecuteReader();
					while (reader.Read())
					{
						po_no = reader["PO_NO"].ToString();
						po_dt = reader["PO_DATE"].ToString();
						rly_cd = reader["RLY_CD"].ToString();
					}
					conn1.Close();
					if (po_no == v_po_no && po_dt == v_po_dt && v_rly_cd == rly_cd)
					{
						string myUpdateQuery = "Update T80_PO_MASTER set REAL_CASE_NO='" + realCSNO + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where CASE_NO= '" + refno + "'";
						OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
						myUpdateCommand.Connection = conn1;
						conn1.Open();
						myUpdateCommand.ExecuteNonQuery();
						conn1.Close();

						try
						{
							string wRegion = "";
							if (Session["Region"].ToString() == "N") { wRegion = "NORTHERN REGION \n 12th FLOOR,CORE-II,SCOPE MINAR,LAXMI NAGAR, DELHI - 110092 \n Phone : +918800018691-95 \n Fax : 011-22024665"; }
							else if (Session["Region"].ToString() == "S") { wRegion = "SOUTHERN REGION \n CTS BUILDING - 2ND FLOOR, BSNL COMPLEX, NO. 16, GREAMS ROAD,  CHENNAI - 600 006 \n Phone : 044-28292807/044- 28292817 \n Fax : 044-28290359"; }
							else if (Session["Region"].ToString() == "E") { wRegion = "EASTERN REGION \n CENTRAL STATION BUILDING(METRO), 56, C.R. AVENUE,3rd FLOOR,KOLKATA-700 012  \n Fax : 033-22348704"; }
							else if (Session["Region"].ToString() == "W") { wRegion = "WESTERN REGION \n 5TH FLOOR, REGENT CHAMBER, ABOVE STATUS RESTAURANT,NARIMAN POINT,MUMBAI-400021 \n Phone : 022-68943400/68943445"; }
							else if (Session["Region"].ToString() == "C") { wRegion = "Central Region"; }
							else if (Session["Region"].ToString() == "Q") { wRegion = "CO QA Division"; }
							string rcase_no = Convert.ToString((e.Item.FindControl("txtRealCSNO") as TextBox).Text.Trim());
							OracleCommand cmd_vend = new OracleCommand("Select T13.VEND_CD,T05.VEND_NAME,NVL2(T05.VEND_ADD2,T05.VEND_ADD1||'/'||T05.VEND_ADD2,T05.VEND_ADD1)||'/'||T03.CITY VEND_ADDRESS, T05.VEND_EMAIL from T13_PO_MASTER T13,T05_VENDOR T05, T03_CITY T03 where T13.VEND_CD=T05.VEND_CD and T05.VEND_CITY_CD=T03.CITY_CD and CASE_NO='" + rcase_no + "'", conn1);
							conn1.Open();
							OracleDataReader reader1 = cmd_vend.ExecuteReader();
							string vend_cd = "", vend_add = "", vend_email = "";
							while (reader1.Read())
							{
								vend_cd = Convert.ToString(reader1["VEND_CD"]);
								vend_add = Convert.ToString(reader1["VEND_ADDRESS"]);
								vend_email = Convert.ToString(reader1["VEND_EMAIL"]);

							}
							conn1.Close();

							OracleCommand cmd = new OracleCommand("Select VEND_EMAIL from T05_VENDOR where VEND_CD=" + vend_cd, conn1);
							conn1.Open();
							string vend_mail = Convert.ToString(cmd.ExecuteScalar());
							conn1.Close();


							string mail_body = "Dear Sir/Madam,\n\n In Reference to your PO: No. " + Convert.ToString(e.Item.Cells[3].Text) + " dated.  " + Convert.ToString(e.Item.Cells[4].Text) + " the Case No. alloted is  -  " + rcase_no + ". Kindly mention this Case No. while placing call on RITES. Thanks for using RITES Inspection Services. \n NATIONAL INSPECTION HELP LINE NUMBER : 1800 425 7000 (TOLL FREE). \n\n" + wRegion + ".";
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
							else if (Session["Region"].ToString() == "Q")
							{
								sender = "ritescqa@rites.com";
							}

							if (vend_mail != "")
							{
								MailMessage mail = new MailMessage();
								mail.To = vend_mail;
								mail.From = sender;
								mail.Subject = "Case No. allocated against PO registered by you on our Portal.";
								mail.Body = mail_body;
								mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
								SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
								mail.Priority = MailPriority.High;
								SmtpMail.Send(mail);
							}
						}
						catch (Exception ex)
						{
							string str1;
							str1 = ex.Message;
						}
					}
					else
					{
						DisplayAlert("Vendors PO NO, PO Date OR Client Does not match with the Real Case Nos PO NO, PO Date OR Client.!!!");

					}
				}
				else
				{
					DisplayAlert("PLEASE ENTER 9 CHARACTERS CASE NUMBER!!!");
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
			DgPO1.EditItemIndex = -1;
			DgPO1.Columns[10].Visible = false;
			fillgrid();
		}

		private void DgPO1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{

			string fpath = Server.MapPath("/RBS/");
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				fpath = fpath + Convert.ToString(e.Item.Cells[11].Text);
				if (File.Exists(fpath) == false)
				{
					e.Item.Cells[11].Text = "<Font Face=Verdana Color=RED>No PO</Font>";
				}
				else
				{
					e.Item.Cells[11].Text = "<a href=" + Convert.ToString(e.Item.Cells[11].Text) + ">Download PO</a>";
				}
			}

		}






	}
}