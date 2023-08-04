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

namespace RBS.Contracts_Form
{
	public partial class Contracts_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		private int code = new int();
		string Action;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelConfirm.Attributes.Add("OnClick", "JavaScript:del();");

			if (Convert.ToString(Request.Params["CONTRACT_ID"]) == null || Convert.ToString(Request.Params["CONTRACT_ID"]) == "")
			{
				code = 0;
				Action = "";
				lblCCode.Visible = false;

			}
			else
			{
				code = Convert.ToInt32(Request.Params["CONTRACT_ID"].Trim());
				Action = Convert.ToString(Request.Params["ACTION"].Trim());
				lblCCode.Text = code.ToString();
				lblCCode.Visible = true;

			}

			if (!(IsPostBack))
			{
				fill_lstCO();

				if (Action == "D")
				{
					show();
					btnSave.Visible = false;
					btnDelConfirm.Visible = true;

				}
				else if (Action == "E")
				{
					show();
					btnSave.Enabled = true;
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
			this.grdCity.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grdCity_ItemDataBound);

		}
		#endregion

		private void fill_lstCO()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{

				lstCO.Items.Clear();
				DataSet ds = new DataSet();
				OracleCommand cmd = new OracleCommand("Select CO_CD,CO_NAME From T08_IE_CONTROLL_OFFICER Where CO_REGION='" + Session["Region"].ToString() + "' Order By CO_NAME", conn1);
				OracleDataAdapter da = new OracleDataAdapter(cmd);
				ListItem lst;
				da.SelectCommand = cmd;
				da.Fill(ds, "Table");
				//
				lst = new ListItem();
				lst.Value = "0";
				lst.Text = " ";
				lstCO.Items.Add(lst);
				//
				for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
				{
					lst = new ListItem();
					lst.Value = ds.Tables[0].Rows[i]["CO_CD"].ToString();
					lst.Text = ds.Tables[0].Rows[i]["CO_NAME"].ToString();
					lstCO.Items.Add(lst);
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

		void show()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				DataSet dsP = new DataSet();
				string str1 = ("select CLIENT_NAME, CONTRACT_NO, TO_CHAR(CONT_PER_FROM,'DD/MM/YYYY')CONT_FROM, TO_CHAR(CONT_PER_TO,'DD/MM/YYYY')CONT_TO, CONTRACT_FEE_NUM, CONTRACT_CM, CONTRACT_SPECIAL_CONDN, CONTRACT_PANALTY, CONT_INSP_FEE, SCOPE_OF_WORK, TO_CHAR(OFFER_DT,'DD/MM/YYYY')OFFER_DATE, EXP_OR, STATUS, TO_CHAR(CONT_SIGN_DT,'DD/MM/YYYY') CONT_SIGN_DATE from T57_ONGOING_CONTRACTS where REGION_CODE='" + Session["Region"].ToString() + "' AND CONTRACT_ID=" + code);
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					throw new System.Exception("No Record Found!!! For The Given Code");
				}
				else
				{
					txtClient.Text = dsP.Tables[0].Rows[0]["CLIENT_NAME"].ToString();
					txtConName.Text = dsP.Tables[0].Rows[0]["CONTRACT_NO"].ToString();
					frmDt.Text = Convert.ToString(dsP.Tables[0].Rows[0]["CONT_FROM"]);
					toDt.Text = Convert.ToString(dsP.Tables[0].Rows[0]["CONT_TO"]);
					txtConFee.Text = Convert.ToString(dsP.Tables[0].Rows[0]["CONTRACT_FEE_NUM"]);
					lstCO.SelectedValue = Convert.ToString(dsP.Tables[0].Rows[0]["CONTRACT_CM"]);
					txtConCond.Text = Convert.ToString(dsP.Tables[0].Rows[0]["CONTRACT_SPECIAL_CONDN"]);
					txtPanelty.Text = Convert.ToString(dsP.Tables[0].Rows[0]["CONTRACT_PANALTY"]);
					txtInspFee.Text = Convert.ToString(dsP.Tables[0].Rows[0]["CONT_INSP_FEE"]);
					txtScopeofWork.Text = Convert.ToString(dsP.Tables[0].Rows[0]["SCOPE_OF_WORK"]);
					txtOfferDt.Text = Convert.ToString(dsP.Tables[0].Rows[0]["OFFER_DATE"]);
					txtExpOR.Text = Convert.ToString(dsP.Tables[0].Rows[0]["EXP_OR"]);
					ddlOfferStatus.SelectedValue = Convert.ToString(dsP.Tables[0].Rows[0]["STATUS"]);
					txtOffSignDt.Text = Convert.ToString(dsP.Tables[0].Rows[0]["CONT_SIGN_DATE"]);
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
			}
		}

		void search()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			DataSet dsP1 = new DataSet();
			string str1 = "select CONTRACT_ID,CLIENT_NAME,CONTRACT_NO,TO_CHAR(CONT_PER_FROM,'DD/MM/YYYY') CONT_PER_FROM,TO_CHAR(CONT_PER_TO,'DD/MM/YYYY') CONT_PER_TO, CO_NAME, CONT_INSP_FEE,'CONTRACTS/'||CONTRACT_ID||'.PDF' CON_DOC from T08_IE_CONTROLL_OFFICER T08, T57_ONGOING_CONTRACTS T57 where T57.CONTRACT_CM=T08.CO_CD ";
			if (txtClient.Text.Trim() != "")
			{
				str1 = str1 + " and upper(CLIENT_NAME) Like upper('" + txtClient.Text.Trim() + "%')";
				//grdCity.CurrentPageIndex=0;
			}
			if (txtConName.Text.Trim() != "")
			{
				str1 = str1 + " and upper(CONTRACT_NO) LIKE upper('" + txtConName.Text.Trim() + "%')";
				//grdCity.CurrentPageIndex=0;
			}


			str1 = str1 + " order by CLIENT_NAME";

			OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			dsP1.Clear();
			da.Fill(dsP1, "Table");
			if (dsP1.Tables[0].Rows.Count == 0)
			{
				grdCity.Visible = false;

			}
			else
			{

				try
				{
					//int aa=grdCity.CurrentPageIndex;
					grdCity.DataSource = dsP1;
					if (grdCity.CurrentPageIndex > (dsP1.Tables[0].Rows.Count / 15))
					{
						grdCity.CurrentPageIndex = 0;
					}
					grdCity.DataBind();
					grdCity.Visible = true;
				}
				catch (Exception ex)
				{
					string str;
					str = ex.Message;
					string str2 = str.Replace("\n", "");
					//DisplayAlert("Sorry, their is some error in search. so, plz try again!!!");
					Response.Redirect("Contracts_Form.aspx");
				}
				finally
				{
					conn1.Close();
				}

			}
			conn1.Close();

		}
		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			try
			{
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				conn1.Open();
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				int CD = 0;
				Int64 w_cont_fee = 0;
				if (txtConFee.Text.Trim() != "")
				{
					w_cont_fee = Convert.ToInt64(txtConFee.Text.Trim());
				}
				if (code == 0)
				{

					string str3 = "select NVL(max(CONTRACT_ID),0) from T57_ONGOING_CONTRACTS";
					OracleCommand myInsertCommand = new OracleCommand();
					myInsertCommand.CommandText = str3;
					myInsertCommand.Connection = conn1;
					CD = Convert.ToInt32(myInsertCommand.ExecuteScalar());
					code = (CD + 1);

					string myInsertQuery = "INSERT INTO T57_ONGOING_CONTRACTS(CONTRACT_ID,CLIENT_NAME,CONTRACT_NO,CONT_PER_FROM,CONT_PER_TO,CONTRACT_FEE,CONTRACT_CM,CONTRACT_SPECIAL_CONDN,CONTRACT_PANALTY,REGION_CODE,USER_ID,DATETIME,CONT_INSP_FEE,SCOPE_OF_WORK,CONTRACT_FEE_NUM,OFFER_DT,EXP_OR,STATUS,CONT_SIGN_DT) values(" + code + ",'" + txtClient.Text + "','" + txtConName.Text + "',to_date('" + frmDt.Text + "','dd/mm/yyyy'),to_date('" + toDt.Text + "','dd/mm/yyyy'),'','" + lstCO.SelectedValue + "','" + txtConCond.Text + "','" + txtPanelty.Text + "','" + Session["REGION"].ToString() + "','" + Session["Uname"].ToString() + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),'" + txtInspFee.Text + "','" + txtScopeofWork.Text + "'," + w_cont_fee + ",to_date('" + txtOfferDt.Text + "','dd/mm/yyyy'),'" + txtExpOR.Text + "','" + ddlOfferStatus.SelectedValue + "',to_date('" + txtOffSignDt.Text + "','dd/mm/yyyy'))";
					myInsertCommand.CommandText = myInsertQuery;
					myInsertCommand.Connection = conn1;
					myInsertCommand.ExecuteNonQuery();
					conn1.Close();
					lblCCode.Text = code.ToString();
					lblCCode.Visible = true;
					upload_contract();

				}
				else
				{
					OracleCommand myUpdateCommand = new OracleCommand();
					string myUpdateQuery = "Update T57_ONGOING_CONTRACTS set CLIENT_NAME ='" + txtClient.Text + "', CONTRACT_NO ='" + txtConName.Text + "', CONT_PER_FROM =to_date('" + frmDt.Text + "','dd/mm/yyyy'), CONT_PER_TO =to_date('" + toDt.Text + "','dd/mm/yyyy'),CONTRACT_FEE_NUM='" + w_cont_fee + "',CONTRACT_CM=" + lstCO.SelectedValue + ",CONTRACT_SPECIAL_CONDN='" + txtConCond.Text + "',CONTRACT_PANALTY='" + txtPanelty.Text + "',CONT_INSP_FEE='" + txtInspFee.Text + "',SCOPE_OF_WORK='" + txtScopeofWork.Text + "',USER_ID='" + Session["Uname"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),OFFER_DT=to_date('" + txtOfferDt.Text + "','dd/mm/yyyy'),EXP_OR='" + txtExpOR.Text + "', STATUS='" + ddlOfferStatus.SelectedValue + "',CONT_SIGN_DT=to_date('" + txtOffSignDt.Text + "','dd/mm/yyyy') where CONTRACT_ID=" + code;
					myUpdateCommand.CommandText = myUpdateQuery;
					myUpdateCommand.Connection = conn1;
					int count = myUpdateCommand.ExecuteNonQuery();
					if ((count == 0))
					{
						throw new System.Exception("No Record Found!!! Any Other User had Deleted Your Record While you were Modifying");
					}

					conn1.Close();
					upload_contract();
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
			}


		}

		void upload_contract()
		{
			if (File1.PostedFile != null && File1.PostedFile.ContentLength > 0)
			{
				string fn = "", MyFile = "", fx = "";
				MyFile = lblCCode.Text;
				fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
				fx = System.IO.Path.GetExtension(File1.PostedFile.FileName).ToUpper().Substring(1);
				String SaveLocation = null;
				if (fx == "PDF")
				{
					SaveLocation = Server.MapPath("CONTRACTS/" + MyFile + ".PDF");
				}
				else
				{
					DisplayAlert("Kindly Upload PDF File only");
				}

				File1.PostedFile.SaveAs(SaveLocation);
				DisplayAlert("Contract Uploaded!!!");

			}

		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			search();
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Contracts_Form.aspx");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("MainForm.aspx");
		}

		protected void btnDelConfirm_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				string myDeleteQuery = ("Delete T57_ONGOING_CONTRACTS where CONTRACT_ID=" + code);
				OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
				myOracleCommand.Connection = conn1;
				conn1.Open();
				myOracleCommand.ExecuteNonQuery();
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
			}
			Response.Redirect("Contracts_Form.aspx");

		}

		private void grdCity_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			string fpath = Server.MapPath("/RBS/");
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				fpath = fpath + Convert.ToString(e.Item.Cells[9].Text);
				if (File.Exists(fpath) == false)
				{
					e.Item.Cells[9].Text = "<Font Face=Verdana Color=RED>No Document</Font>";
				}
				else
				{
					e.Item.Cells[9].Text = "<a href=" + Convert.ToString(e.Item.Cells[9].Text) + ">Download Contract</a>";
				}
			}

		}
	}
}