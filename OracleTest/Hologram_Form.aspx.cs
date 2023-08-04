using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Hologram_Form
{
	public partial class Hologram_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected System.Web.UI.WebControls.Button btnDelConfirm;
		string HGNoFR, HGNoTO, action;
		int sfr, sto, count;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnDelete.Attributes.Add("OnClick", "JavaScript:del();");
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");

			if (Convert.ToString(Request.QueryString["HG_NO_FR"]) == "" || Convert.ToString(Request.QueryString["HG_NO_TO"]) == null)
			{
				action = "A";
			}
			else
			{
				action = Request.QueryString["Action"];
				HGNoFR = Request.QueryString["HG_NO_FR"].ToString();
				HGNoTO = Request.QueryString["HG_NO_TO"].ToString();
			}
			lblReg1.Text = Session["Region"].ToString();
			lblReg2.Text = Session["Region"].ToString();
			if (!(IsPostBack))
			{

				fill_IEtoWhomeIssued();
				if (Convert.ToString(Request.QueryString["HG_NO_FR"]) == "" || Convert.ToString(Request.QueryString["HG_NO_TO"]) == null)
				{
					btnDelete.Visible = false;
					btnAddNew.Visible = false;
					action = "A";
				}
				else
				{
					action = Request.QueryString["Action"];
					HGNoFR = Request.QueryString["HG_NO_FR"].ToString();
					HGNoTO = Request.QueryString["HG_NO_TO"].ToString();
					find();

					if (action == "M")
					{
						btnSave.Visible = true;
						btnDelete.Visible = false;
					}
					else if (action == "D")
					{
						btnDelete.Visible = true;
						btnSave.Visible = false;
					}

				}
			}
		}



		public void find()
		{
			try
			{
				OracleCommand cmd = new OracleCommand("select HG_NO_FR,HG_NO_TO,to_char(HG_ISSUE_DT,'dd/mm/yyyy') ISSUE_DT,HG_IECD from T31_HOLOGRAM_ISSUED where HG_NO_FR='" + HGNoFR + "' and HG_NO_TO='" + HGNoTO + "' AND HG_REGION='" + Session["Region"].ToString() + "'", conn1);
				conn1.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					txtCertFrom.Text = Convert.ToString(reader["HG_NO_FR"]);
					lblF.Text = Convert.ToString(reader["HG_NO_FR"]);
					txtCertTo.Text = Convert.ToString(reader["HG_NO_TO"]);
					lblT.Text = Convert.ToString(reader["HG_NO_TO"]);
					lstIE.SelectedValue = Convert.ToString(reader["HG_IECD"]);
					txtDOI.Text = Convert.ToString(reader["ISSUE_DT"]);

				}
				reader.Close();
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

		public void fill_IEtoWhomeIssued()
		{
			try
			{
				lstIE.Items.Clear();
				OracleCommand cmd = new OracleCommand("select IE_CD,IE_NAME from T09_IE where IE_STATUS is null and IE_REGION ='" + Session["Region"].ToString() + "' ORDER BY IE_NAME", conn1);
				OracleDataReader dr;
				conn1.Open();
				dr = cmd.ExecuteReader();
				ListItem lst;
				while (dr.Read())
				{
					lst = new ListItem();
					lst.Text = Convert.ToString(dr["IE_NAME"]);
					lst.Value = Convert.ToString(dr["IE_CD"]);
					lstIE.Items.Add(lst);
				}
				lstIE.Items.Insert(0, "");
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

			try
			{
				OracleCommand cmd2 = new OracleCommand("SELECT sign(sysdate - TO_DATE('" + txtDOI.Text + "','DD/MM/YYYY')) FROM dual", conn1);
				conn1.Open();
				int ss = Convert.ToInt32(cmd2.ExecuteScalar());

				if (ss == 1)
				{

					if (Convert.ToString(Request.QueryString["HG_NO_FR"]) == "" || Convert.ToString(Request.QueryString["HG_NO_TO"]) == null)
					{
						action = "A";
					}
					else
					{
						action = Request.QueryString["Action"];
					}
					sfr = Convert.ToInt32(txtCertFrom.Text);
					sto = Convert.ToInt32(txtCertTo.Text);
					OracleCommand mySelectCommand = new OracleCommand();
					if (action == "M")
					{
						mySelectCommand = new OracleCommand("Select count(*) from  T31_HOLOGRAM_ISSUED where (trim(HG_NO_FR)<>'" + lblF.Text + "' and trim(HG_NO_TO)<>'" + lblT.Text + "') and ((" + sfr + " between HG_NO_FR and HG_NO_TO) or (" + sto + "  between HG_NO_FR and HG_NO_TO) or (" + sfr + " < HG_NO_FR and " + sto + "  > HG_NO_TO)) AND HG_REGION='" + Session["REGION"].ToString() + "'", conn1);
					}
					else if (action == "A")
					{
						mySelectCommand = new OracleCommand("Select count(*) from  T31_HOLOGRAM_ISSUED where ((" + sfr + " between HG_NO_FR and HG_NO_TO) or (" + sto + "  between HG_NO_FR and HG_NO_TO) or (" + sfr + " < HG_NO_FR and " + sto + "  > HG_NO_TO)) AND HG_REGION='" + Session["REGION"].ToString() + "'", conn1);
					}
					count = Convert.ToInt32(mySelectCommand.ExecuteScalar());

					if (count <= 0 && action == "A")
					{
						save();
					}
					else if (count <= 0 && action == "M")
					{
						//						OracleCommand mySelectCommand1 =new OracleCommand("Select count(*) from  T20_IC where TRIM(BK_NO)  = upper('"+ txtBKNo.Text.Trim()+"') and (SET_NO between '"+lblF.Text+"' and '"+lblT.Text+"') and (SET_NO not between "+sfr+" and "+sto+") and substr(CASE_NO,1,1)='"+Session["Region"].ToString()+"'",conn1);
						//						int count1 = Convert.ToInt32(mySelectCommand1.ExecuteScalar());
						//						if(count1<=0)
						//						{
						modify();
						//						}
						//						else
						//						{
						//							DisplayAlert("The Inspection Certificate is already been used in the range you are modifying!!");
						//						}
					}
					else
					{
						DisplayAlert("Range of Entered Hologram No. From to Hologram No. To Already Present in Database!!!");
					}
				}
				else
				{
					DisplayAlert("The Date Of Issue To IE Cannot be greater then todays date");
				}

			}
			catch (Exception ex)
			{
				string str;
				str = (ex.Message);
				string str1 = str.Replace("\n", "");
				Response.Redirect("Error_Form.aspx?err=" + str1);
			}
			finally
			{
				conn1.Close();
			}
		}

		public void save()
		{
			OracleCommand cmd1 = new OracleCommand("select NVL(IE_STATUS,'W') from T09_IE where IE_CD=" + lstIE.SelectedValue, conn1);
			string status = Convert.ToString(cmd1.ExecuteScalar());
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
			string ss = Convert.ToString(cmd2.ExecuteScalar());
			if (status == "W")
			{
				//OracleCommand myInsertCommand =new OracleCommand("INSERT INTO T10_IC_BOOKSET values(upper('" + txtBKNo.Text.Trim() + "'), '" + txtCertFrom.Text.Trim() + "', '" + txtCertTo.Text.Trim() + "', to_date('" + txtDOI.Text + "','dd/mm/yyyy')," + lstIE.SelectedValue + ",'" + lstBKSubmit.SelectedItem.Value + "',to_date('" + txtBKSubmitDt.Text + "','dd/mm/yyyy'),'"+Session["Region"].ToString()+"')",conn1);
				OracleCommand myInsertCommand = new OracleCommand("INSERT INTO T31_HOLOGRAM_ISSUED(HG_REGION,HG_NO_FR, HG_NO_TO, HG_ISSUE_DT, HG_IECD,USER_ID, DATETIME) values( '" + Session["Region"].ToString() + "','" + txtCertFrom.Text.Trim() + "','" + txtCertTo.Text.Trim() + "', to_date('" + txtDOI.Text + "','dd/mm/yyyy')," + lstIE.SelectedValue + ", '" + Session["Uname"].ToString() + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))", conn1);
				myInsertCommand.ExecuteNonQuery();
				clear();
				btnSave.Visible = true;
				btnAddNew.Visible = true;
				btnSave.Enabled = false;
				conn1.Close();
				DisplayAlert("Your Record is Saved!!! ");
			}
			else
			{
				DisplayAlert("You Cannot Issue a New HOLOGRAM To a Retired or Left IE!!! ");
			}
		}

		public void clear()
		{
			txtCertFrom.Text = "";
			txtCertTo.Text = "";
			txtDOI.Text = "";
			lstIE.SelectedIndex = 0;
			btnCancel.Visible = true;
		}

		public void modify()
		{
			//			int count1=0;
			//			int count2=0;
			//			if(txtCutOffSetDt.Text.Trim()!="" && txtCutOffSetNo.Text.Trim()!="")
			//			{
			//				OracleCommand mySelectCommand1 =new OracleCommand("Select count(*) from  T20_IC where TRIM(BK_NO)  = upper('"+ txtBKNo.Text.Trim()+"') and (SET_NO > '"+txtCutOffSetNo.Text.Trim()+"') and IE_CD="+lstIE.SelectedValue+" and IC_DT<=to_date('"+txtCutOffSetDt.Text.Trim()+"','dd/mm/yyyy')",conn1);
			//				count1 = Convert.ToInt32(mySelectCommand1.ExecuteScalar());
			//
			//				OracleCommand mySelectCommand2 =new OracleCommand("Select count(*) from  T32_HOLOGRAM_CANCEL where (SET_NO > '"+txtCutOffSetNo.Text.Trim()+"') and ISSUE_TO_IECD="+lstIE.SelectedValue+" and STATUS_DT<=to_date('"+txtCutOffSetDt.Text.Trim()+"','dd/mm/yyyy')",conn1);
			//				count2 = Convert.ToInt32(mySelectCommand2.ExecuteScalar());
			//			}

			//			if(count1>0 && count2>0)
			//			{
			//				DisplayAlert("The Last set no. entered is invalid as Book-Sets after this have been Issued / Cancelled before the Cut off Date.");
			//				conn1.Close(); 
			//			}
			//			else if(count1>0)
			//			{
			//				DisplayAlert("The Last set no. entered is invalid as Book-Set after this have been Issued before the Cut off Date.");
			//				conn1.Close(); 
			//			}
			//			else if (count2>0)
			//			{
			//				DisplayAlert("The Last set no. entered is invalid as Book-Set after this have been Cancelled before the Cut off Date.");
			//				conn1.Close(); 
			//			}
			//			else
			//			{
			OracleCommand mySelectCommand2 = new OracleCommand("Select count(*) from  T32_HOLOGRAM_CANCEL where ((HG_NO_FR between " + Convert.ToInt64(lblF.Text.Trim()) + " and " + Convert.ToInt64(txtCertFrom.Text.Trim()) + ") or (HG_NO_TO between " + Convert.ToInt64(lblT.Text.Trim()) + " and " + Convert.ToInt64(txtCertTo.Text.Trim()) + ") OR (HG_NO_FR between " + Convert.ToInt64(txtCertFrom.Text.Trim()) + " and " + Convert.ToInt64(txtCertTo.Text.Trim()) + ") OR (HG_NO_TO between " + Convert.ToInt64(txtCertFrom.Text.Trim()) + " and " + Convert.ToInt64(txtCertTo.Text.Trim()) + ")) and HG_REGION='" + Session["Region"].ToString() + "'", conn1);
			int count = Convert.ToInt32(mySelectCommand2.ExecuteScalar());

			if (count == 0)
			{
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				//OracleCommand myUpdateCommand = new OracleCommand("Update T10_IC_BOOKSET set SET_NO_FR ='" + txtCertFrom.Text.Trim() + "', SET_NO_TO ='" + txtCertTo.Text.Trim() + "',ISSUE_DT = to_date('" + txtDOI.Text + "','dd/mm/yyyy'),ISSUE_TO_IECD=" + lstIE.SelectedItem.Value + ", BK_SUBMITTED='" + lstBKSubmit.SelectedValue + "', BK_SUBMIT_DT=to_date('" + txtBKSubmitDt.Text + "','dd/mm/yyyy') where TRIM(BK_NO)=upper('" + txtBKNo.Text.Trim() + "') and SET_NO_FR = '" + lblF.Text +"' and SET_NO_TO='"+lblT.Text+"' and REGION='"+Session["Region"].ToString()+"'",conn1); 
				OracleCommand myUpdateCommand = new OracleCommand("Update T31_HOLOGRAM_ISSUED set HG_NO_FR ='" + txtCertFrom.Text.Trim() + "', HG_NO_TO ='" + txtCertTo.Text.Trim() + "',HG_ISSUE_DT = to_date('" + txtDOI.Text + "','dd/mm/yyyy'),HG_IECD=" + lstIE.SelectedItem.Value + ", USER_ID='" + Session["Uname"].ToString() + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where HG_NO_FR = '" + lblF.Text + "' and HG_NO_TO='" + lblT.Text + "' and HG_REGION='" + Session["Region"].ToString() + "'", conn1);
				myUpdateCommand.ExecuteNonQuery();
				conn1.Close();
				DisplayAlert("Your Record is Modified!!! ");
			}
			else
			{
				DisplayAlert("The  Hologram No. is  Cancelled/Destroyed between the Range of Holgram No. From and Hologram No. To, soo u cannot modify it.");

			}
			//			}
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Hologram_Search_Form.aspx");
		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				//				conn1.Open(); 
				//				OracleCommand mySelectCommand1 =new OracleCommand("Select count(*) from  T20_IC where TRIM(BK_NO)  = upper('"+ txtBKNo.Text.Trim()+"') and (SET_NO between '"+lblF.Text+"' and '"+lblT.Text+"') and (SET_NO not between "+sfr+" and "+sto+") AND substr(CASE_NO,1,1)='"+Session["REGION"].ToString()+"'",conn1);
				//				int count1 = Convert.ToInt32(mySelectCommand1.ExecuteScalar());
				//				conn1.Close(); 
				//				if(count1<=0)
				//				{
				OracleCommand mySelectCommand2 = new OracleCommand("Select count(*) from  T32_HOLOGRAM_CANCEL where ((HG_NO_FR between " + Convert.ToInt64(lblF.Text.Trim()) + " and " + Convert.ToInt64(txtCertFrom.Text.Trim()) + ") or (HG_NO_TO between " + Convert.ToInt64(lblT.Text.Trim()) + " and " + Convert.ToInt64(txtCertTo.Text.Trim()) + ") OR (HG_NO_FR between " + Convert.ToInt64(txtCertFrom.Text.Trim()) + " and " + Convert.ToInt64(txtCertTo.Text.Trim()) + ") OR (HG_NO_TO between " + Convert.ToInt64(txtCertFrom.Text.Trim()) + " and " + Convert.ToInt64(txtCertTo.Text.Trim()) + ")) and HG_REGION='" + Session["Region"].ToString() + "'", conn1);
				conn1.Open();
				int count = Convert.ToInt32(mySelectCommand2.ExecuteScalar());

				if (count == 0)
				{
					OracleCommand myDeleteCommand = new OracleCommand("Delete T31_HOLOGRAM_ISSUED where HG_NO_FR = '" + txtCertFrom.Text + "' and HG_NO_TO= '" + txtCertTo.Text + "' and HG_REGION='" + Session["Region"].ToString() + "'", conn1);

					myDeleteCommand.ExecuteNonQuery();
					txtCertFrom.Text = "";
					txtCertTo.Text = "";
					txtDOI.Text = "";
					lstIE.SelectedIndex = 0;
				}
				else
				{
					DisplayAlert("The  Hologram No. is  Cancelled/Destroyed between the Range of Holgram No. From and Hologram No. To, soo u cannot delete it.");

				}
				//				}
				//				else
				//				{
				//					DisplayAlert("The Inspection Certificate is already been used in the range you are Deleting!!!");
				//				}
				//				conn1.Close(); 
			}
			catch (Exception ex)
			{
				string str;
				str = (ex.Message);
				string str1 = str.Replace("\n", "");
				Response.Redirect("Error_Form.aspx?err=" + str1);
			}
			finally
			{
				conn1.Close();
			}

		}

		protected void btnAddNew_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Hologram_Form.aspx");
		}
	}
}