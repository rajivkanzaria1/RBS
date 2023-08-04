using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Ongoing_Contract_Form
{
	public partial class Ongoing_Contract_Form : System.Web.UI.Page
	{
		OracleConnection conn	= new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		string Action;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if (!(IsPostBack))
			{
				ListItem lst = new ListItem();
				lst.Text = "";
				lst.Value = "";
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

				ListItem lst1 = new ListItem();
				lst1.Text = "Man days Basis";
				lst1.Value = "D";
				lstCFeeType.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "Hourly Basis";
				lst1.Value = "H";
				lstCFeeType.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "Lump sum";
				lst1.Value = "L";
				lstCFeeType.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "Percentage Basis";
				lst1.Value = "P";
				lstCFeeType.Items.Add(lst1);
				lstCFeeType.Items.Insert(0, "");



				ListItem lst2 = new ListItem();
				lst2.Text = "Fee Inclusive Service Tax";
				lst2.Value = "I";
				lstCTaxType.Items.Add(lst2);
				lst2 = new ListItem();
				lst2.Text = "Tax/VAT Charged separately";
				lst2.Value = "X";
				lstCTaxType.Items.Add(lst2);
				lstCTaxType.Items.Insert(0, "");

				if (Convert.ToString(Request.Params["CONTRACT_CD"]) == "" || Convert.ToString(Request.Params["CONTRACT_CD"]) == null)
				{
					Label4.Visible = false;
					lblContractCD.Visible = false;
				}
				else
				{
					Label4.Visible = true;
					lblContractCD.Visible = true;
					lblContractCD.Text = Request.Params["CONTRACT_CD"].ToString();
					show();
				}
			}
		}

		void show()
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			string MySql = "Select CONTRACT_CD,CLIENT_TYPE,CLIENT_SNAME,CONTRACT_NO,to_char(CONT_PERIOD_FR,'dd/mm/yyyy') PER_FR,to_char(CONT_PERIOD_TO,'dd/mm/yyyy')PER_TO,CONT_FEE_TYPE,CONT_TAX_TYPE,CONT_FEE,MIN_FEE,MAX_FEE,CONT_CM,CONT_SPEC_CONDS,CONT_PENALTY,CONT_REGION from ONGOING_NONRLY_CONTRACTS" +
				" Where CONTRACT_CD='" + lblContractCD.Text.Trim() + "' ";
			try
			{
				conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				OracleCommand cmd = new OracleCommand(MySql, conn);
				conn.Open();
				OracleDataReader MyReader = cmd.ExecuteReader();
				while (MyReader.Read())
				{
					lstClientType.SelectedValue = MyReader["CLIENT_TYPE"].ToString();
					fill_Rly();
					lstBPO_Rly.SelectedValue = MyReader["CLIENT_SNAME"].ToString();
					txtContNo.Text = MyReader["CONTRACT_NO"].ToString();
					txtContFrom.Text = MyReader["PER_FR"].ToString();
					txtContTo.Text = MyReader["PER_TO"].ToString();
					lstCFeeType.SelectedValue = MyReader["CONT_FEE_TYPE"].ToString();
					lstCTaxType.SelectedValue = MyReader["CONT_TAX_TYPE"].ToString();
					txtCOFee.Text = MyReader["CONT_FEE"].ToString();
					txtMinFee.Text = MyReader["MIN_FEE"].ToString();
					txtMaxFee.Text = MyReader["MAX_FEE"].ToString();
					lstRegionCd.SelectedValue = MyReader["CONT_REGION"].ToString();
					cm_populate();
					lstCO.SelectedValue = MyReader["CONT_CM"].ToString();
					txtSConds.Text = MyReader["CONT_SPEC_CONDS"].ToString();
					txtPenalty.Text = MyReader["CONT_PENALTY"].ToString();

				}
				string fpath1 = Server.MapPath("/RBS/CONTRACTS/" + lblContractCD.Text.Trim() + ".TIF");
				if (File.Exists(fpath1) == false)
				{
					Label12.Visible = true;
					File1.Visible = true;
					HypContract.Visible = false;
				}
				else
				{
					HypContract.NavigateUrl = "/RBS/CONTRACTS/" + lblContractCD.Text.Trim() + ".TIF";
					HypContract.Visible = true;
					File1.Visible = false;


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
				conn.Close();
				conn.Dispose();
			}

		}

		public void fill_Rly()
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			lstBPO_Rly.Items.Clear();
			DataSet dsP = new DataSet();
			string str = "";
			if (lstClientType.SelectedValue == "R")
			{
				str = "Select RLY_CD,RAILWAY ORGN from T91_RAILWAYS Order by RLY_CD";
			}
			else
			{
				str = "Select distinct(upper(trim(BPO_RLY))) RLY_CD, BPO_ORGN ORGN from T12_BILL_PAYING_OFFICER WHERE BPO_TYPE='" + lstClientType.SelectedValue + "' Order by RLY_CD";
			}
			OracleDataAdapter da = new OracleDataAdapter(str, conn);
			OracleCommand myOracleCommand = new OracleCommand(str, conn);
			ListItem lst;
			conn.Open();
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			conn.Close();
			for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
			{
				lst = new ListItem();
				lst.Text = dsP.Tables[0].Rows[i]["ORGN"].ToString();
				lst.Value = dsP.Tables[0].Rows[i]["RLY_CD"].ToString();
				lstBPO_Rly.Items.Add(lst);
			}
			conn.Dispose();
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
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				conn.Open();
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn);
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				conn.Close();
				string Ttype;
				Ttype = lstCTaxType.SelectedItem.Value;
				if ((Ttype == "X"))
				{
					Ttype = "";
				}

				//				Action = Convert.ToString(Request.QueryString["Action"]);


				if (lblContractCD.Visible == false)
				{
					//						

					string str3 = "select lpad(to_number(Nvl(max(substr(CONTRACT_CD,2,4)),0)+1),4,'0') from ONGOING_NONRLY_CONTRACTS";
					OracleCommand myOracleCommand = new OracleCommand();
					myOracleCommand.CommandText = str3;
					myOracleCommand.Connection = conn;
					conn.Open();
					string ccode = Session["Region"].ToString() + Convert.ToString(myOracleCommand.ExecuteScalar());
					conn.Close();
					//				

					string myInsertQuery = "INSERT INTO ONGOING_NONRLY_CONTRACTS(CONTRACT_CD, CLIENT_TYPE,CLIENT_SNAME, CLIENT_NAME, CONTRACT_NO,CONT_PERIOD_FR,CONT_PERIOD_TO,CONT_FEE_TYPE,CONT_TAX_TYPE,CONT_FEE,MIN_FEE,MAX_FEE,CONT_CM,CONT_SPEC_CONDS,CONT_PENALTY,CONT_REGION,USER_ID,DATETIME) values('" + ccode + "', '" + lstClientType.SelectedValue + "','" + lstBPO_Rly.SelectedValue + "','" + lstBPO_Rly.SelectedItem.Text + "','" + txtContNo.Text.Trim() + "',to_date('" + txtContFrom.Text + "','dd/mm/yyyy'),to_date('" + txtContTo.Text + "','dd/mm/yyyy'),'" + lstCFeeType.SelectedItem.Value + "','" + Ttype + "'," + txtCOFee.Text + "," + txtMinFee.Text + "," + txtMaxFee.Text + "," + lstCO.SelectedValue + ",'" + txtSConds.Text + "','" + txtPenalty.Text + "','" + lstRegionCd.SelectedValue + "','" + Session["Uname"].ToString() + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
					OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
					myInsertCommand.Connection = conn;
					conn.Open();
					myInsertCommand.ExecuteNonQuery();
					conn.Close();
					DisplayAlert("Your Record Has Been Saved!!!");
					lblContractCD.Text = ccode;
					lblContractCD.Visible = true;
					Label4.Visible = true;

					if (File1.PostedFile != null && File1.PostedFile.ContentLength > 0)
					{
						string fn = "", MyFile = "";
						MyFile = ccode.Trim();
						fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
						//				fx =System.IO.Path.GetExtension(File1.PostedFile.FileName).ToUpper().Substring(1);
						String SaveLocation = null;
						SaveLocation = Server.MapPath("CONTRACTS/" + MyFile + ".TIF");
						File1.PostedFile.SaveAs(SaveLocation);
						//DisplayAlert("Case Uploaded!!!");

					}

				}
				else
				{

					//					string Ucode=lblBPOCD.Text;
					string Ucode = lblContractCD.Text;
					string myUpdateQuery = "Update ONGOING_NONRLY_CONTRACTS set CLIENT_TYPE='" + lstClientType.SelectedValue + "', CLIENT_NAME='" + lstBPO_Rly.SelectedItem.Text + "',CLIENT_SNAME='" + lstBPO_Rly.SelectedValue + "', CONTRACT_NO='" + txtContNo.Text.Trim() + "', CONT_PERIOD_FR=to_date('" + txtContFrom.Text + "','dd/mm/yyyy'),CONT_PERIOD_TO=to_date('" + txtContTo.Text + "','dd/mm/yyyy'),CONT_FEE_TYPE='" + lstCFeeType.SelectedItem.Value + "',CONT_TAX_TYPE='" + Ttype + "',CONT_FEE=" + txtCOFee.Text + ",MIN_FEE=" + txtMinFee.Text + ",MAX_FEE=" + txtMaxFee.Text + ",CONT_CM=" + lstCO.SelectedValue + ",CONT_SPEC_CONDS='" + txtSConds.Text + "',CONT_PENALTY='" + txtPenalty.Text + "',CONT_REGION='" + lstRegionCd.SelectedValue + "',USER_ID='" + Session["Uname"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where CONTRACT_CD='" + Ucode + "'";
					OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
					myUpdateCommand.Connection = conn;
					conn.Open();
					myUpdateCommand.ExecuteNonQuery();
					conn.Close();
					if (File1.PostedFile != null && File1.PostedFile.ContentLength > 0)
					{
						string fn = "", MyFile = "";
						MyFile = Ucode.Trim();
						fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
						//				fx =System.IO.Path.GetExtension(File1.PostedFile.FileName).ToUpper().Substring(1);
						String SaveLocation = null;
						SaveLocation = Server.MapPath("CONTRACTS/" + MyFile + ".TIF");
						File1.PostedFile.SaveAs(SaveLocation);
						//DisplayAlert("Case Uploaded!!!");

					}
					DisplayAlert("Your Record Has Been Saved!!!");
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
				conn.Close();
				conn.Dispose();
			}



		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		protected void lstClientType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fill_Rly();
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Ongoing_Contract_Form.aspx");
		}
		void cm_populate()
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				DataSet dsP1 = new DataSet();
				string str2 = "select I.CO_CD,NVL2(D.R_DESIGNATION,I.CO_NAME ||'/'|| D.R_DESIGNATION,I.CO_NAME) CO_NAME from T08_IE_CONTROLL_OFFICER I, T07_RITES_DESIG D where I.CO_DESIG =D.R_DESIG_CD and CO_REGION='" + lstRegionCd.SelectedValue + "'";
				OracleDataAdapter da1 = new OracleDataAdapter(str2, conn);
				OracleCommand myOracleCommand1 = new OracleCommand(str2, conn);
				ListItem lst1;
				conn.Open();
				da1.SelectCommand = myOracleCommand1;
				da1.Fill(dsP1, "Table");
				lst1 = new ListItem();
				for (int j = 0; j <= dsP1.Tables[0].Rows.Count - 1; j++)
				{
					lst1 = new ListItem();
					lst1.Text = dsP1.Tables[0].Rows[j]["CO_NAME"].ToString();
					lst1.Value = dsP1.Tables[0].Rows[j]["CO_CD"].ToString();
					lstCO.Items.Add(lst1);
				}
				lstCO.Items.Insert(0, "");
				conn.Close();
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
				conn.Close();
				conn.Dispose();
			}
		}
		protected void lstRegionCd_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			cm_populate();
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Ongoing_Contracts_Edit.aspx");
		}

		protected void Print_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language=JavaScript>var oWin= window.open('Reports/pfrmOngoing_NonRly_Contracts_Report.aspx','', 'fullscreen=yes, scrollbars=yes');");
			Response.Write("if (oWin==null || typeof(oWin)=='undefined') alert('System has been blocked by POP-UP BLOCKER!!!\\nPlease disable the POP-UP BLOCKER and try again or Please contact your system administrator.');</script>");
		}
	}
}