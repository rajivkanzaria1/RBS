using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.IE_Instructions
{
	public partial class IE_Instructions : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		static string wIECD, wIENAME;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			wIECD = Request.Params["pIECD"].ToString();
			wIENAME = Request.Params["pIENAME"].ToString();
			//			lblIEName.Text=wIENAME;
			fillgrid();
			HyperLink1.NavigateUrl = "/RBS/DSC EXPIRY DATE.pdf";
			if (!(IsPostBack))
			{
				show_dsc_expiry();
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

		protected void btnNext_Click(object sender, System.EventArgs e)
		{
			//			Response.Redirect("Calls_Marked_To_IE.aspx?pIECD="+wIECD+"&pIENAME="+wIENAME);
			if (txtDSCExpiryDT.Text.Trim() == "")
			{
				string msg = "You have not entered your DSC Expiry Date.";
				DisplayAlert1(msg);
			}
			else if (txtDSCExpiryDT.Enabled == false)
			{
				Response.Redirect("IE_Menu.aspx");
			}
			else
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				int err_cd = 0;
				try
				{
					conn1.Open();
					OracleCommand cmd11 = new OracleCommand("Select to_char(sysdate,'yyyymmdd') from dual", conn1);
					string sdate = Convert.ToString(cmd11.ExecuteScalar());
					conn1.Close();

					string myYear, myMonth, myDay;

					myYear = txtDSCExpiryDT.Text.Substring(6, 4);
					myMonth = txtDSCExpiryDT.Text.Substring(3, 2);
					myDay = txtDSCExpiryDT.Text.Substring(0, 2);
					string dt1 = myYear + myMonth + myDay;
					int i = dt1.CompareTo(sdate);
					if (i > 0)
					{

						try
						{
							string updateQuery = "Update T09_IE set DSC_EXPIRY_DT=TO_DATE('" + txtDSCExpiryDT.Text.Trim() + "','DD/MM/YYYY') where IE_CD='" + wIECD + "' ";
							OracleCommand myUpdateCommand = new OracleCommand(updateQuery, conn1);
							conn1.Open();
							myUpdateCommand.ExecuteNonQuery();
							conn1.Close();
						}
						catch (Exception ex)
						{
							string str;
							str = ex.Message;
							string str1 = str.Replace("\n", "");
							Response.Redirect("Error_Form.aspx?err=" + str1);
						}

					}
					else
					{
						err_cd = 1;
					}


					//DisplayAlert("Your Record is Saved!!!");

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
					conn1.Dispose();
				}
				if (err_cd == 0)
				{
					Response.Redirect("IE_Menu.aspx");
				}
				else if (err_cd == 1)
				{
					DisplayAlert("DSC Expiry date cannot be earlier then current date.");
				}
			}


		}
		void show_dsc_expiry()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				conn1.Open();
				OracleCommand cmd11 = new OracleCommand("Select to_char(sysdate,'yyyymmdd') from dual", conn1);
				string sdate = Convert.ToString(cmd11.ExecuteScalar());
				conn1.Close();

				string str = "select TO_CHAR(DSC_EXPIRY_DT,'DD/MM/YYYY') from T09_IE where IE_CD='" + wIECD + "'";
				OracleCommand myOracleCommand = new OracleCommand(str, conn1);
				conn1.Open();
				string dsc_expiry_dt = Convert.ToString(myOracleCommand.ExecuteScalar());
				conn1.Close();
				if (dsc_expiry_dt.Trim() != "")
				{
					string myYear, myMonth, myDay;

					myYear = dsc_expiry_dt.Substring(6, 4);
					myMonth = dsc_expiry_dt.Substring(3, 2);
					myDay = dsc_expiry_dt.Substring(0, 2);
					string dt1 = myYear + myMonth + myDay;
					int i = dt1.CompareTo(sdate);
					if (i > 0)
					{
						txtDSCExpiryDT.Text = dsc_expiry_dt;
						txtDSCExpiryDT.Enabled = false;
					}
					else
					{
						txtDSCExpiryDT.Text = "";
					}
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

		private void DisplayAlert1(string msg)
		{
			msg = msg + " Do You Still Want to Proceed?";
			Response.Write("<script language=JavaScript> var d=confirm('" + msg + "'); if(d==true) location.href='/IE_Menu.aspx';</script>");
		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		void fillgrid()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				conn1.Open();
				OracleCommand cmd1 = new OracleCommand("select NVL(max(MESSAGE_ID),0) MESS_ID from T72_IE_MESSAGES where REGION_CODE='" + Session["Region"].ToString() + "'", conn1);
				int max_id = Convert.ToInt32(cmd1.ExecuteScalar());
				if (max_id != 0)
				{
					OracleCommand cmd2 = new OracleCommand("select MESSAGE||', Letter No. '||LETTER_NO||', Dated: '||to_char(LETTER_DT,'dd/mm/yyyy') MESS from T72_IE_MESSAGES where MESSAGE_ID=" + max_id + " and REGION_CODE='" + Session["Region"] + "'", conn1);
					lblLatestMess.Text = "Latest Instruction: " + Convert.ToString(cmd2.ExecuteScalar());
				}
				conn1.Close();
				DataSet dsP = new DataSet();
				conn1.Open();
				string str1 = "select MESSAGE_ID,MESSAGE,LETTER_NO,to_char(LETTER_DT,'dd/mm/yyyy') LETTER_DT,to_char(MESSAGE_DT,'dd/mm/yyyy')MESSAGE_DATE from T72_IE_MESSAGES where REGION_CODE='" + Session["Region"].ToString() + "' and MESSAGE_ID<>" + max_id + " order by DATETIME DESC";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdInstructions.Visible = false;
					Label13.Text = "No Instructions Uploaded!!!";
				}
				else
				{
					grdInstructions.Visible = true;
					grdInstructions.DataSource = dsP;
					grdInstructions.DataBind();

					//grdInstructions.Rows(0).backcolor=red;
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


	}
}