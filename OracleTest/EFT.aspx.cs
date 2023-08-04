using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.EFT
{
	public partial class EFT : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		string CNO = "", CDT = "", Action = "";
		int BCD = 0;
		int ecode = 0;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelete.Attributes.Add("OnClick", "JavaScript:del();");
			btnSearch.Attributes.Add("OnClick", "JavaScript:validate1();");
			btnFC_List.Attributes.Add("OnClick", "JavaScript:validateBPO();");
			if (Convert.ToString(Request.QueryString["Action"]) == "" || Convert.ToString(Request.QueryString["Action"]) == null)
			{
				Action = "";
				CNO = "";
				CDT = "";
				BCD = 0;
			}
			else
			{
				Action = Convert.ToString(Request.QueryString["Action"]);
				CNO = Convert.ToString(Request.QueryString["CHQ_NO"]);
				CDT = Convert.ToString(Request.QueryString["CHQ_DT"]);
				BCD = Convert.ToInt32(Request.QueryString["BANK_CD"]);
			}

			if (!(IsPostBack))
			{
				DataSet dsP = new DataSet();
				string stra = "select ACC_CD,(ACC_DESC||':'||ACC_CD)ACC_DESC from T95_ACCOUNT_CODES Order by ACC_DESC ";
				OracleDataAdapter da = new OracleDataAdapter(stra, conn1);
				OracleCommand myOracleCommand = new OracleCommand(stra, conn1);
				//ListItem lst; 
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				lstACD.DataValueField = "ACC_CD";
				lstACD.DataTextField = "ACC_DESC";
				lstACD.DataSource = dsP;
				lstACD.DataBind();
				conn1.Close();

				DataSet dsP2 = new DataSet();
				string stra2 = "select BANK_CD,BANK_NAME from T94_BANK where FMIS_BANK_CD is not null order by BANK_NAME";
				OracleDataAdapter da2 = new OracleDataAdapter(stra2, conn1);
				OracleCommand myOracleCommand2 = new OracleCommand(stra2, conn1);
				//ListItem lst; 
				conn1.Open();
				da2.SelectCommand = myOracleCommand2;
				da2.Fill(dsP2, "Table");
				lstBank.DataValueField = "BANK_CD";
				lstBank.DataTextField = "BANK_NAME";
				lstBank.DataSource = dsP2;
				lstBank.DataBind();
				conn1.Close();
				lstBank.Items.Insert(0, "");
				if (Action == "M")
				{
					show();
					btnDelete.Visible = true;
				}
				else
				{
					btnDelete.Visible = false;
				}
				if (Session["Role_CD"].ToString() == "4")
				{
					btnSave.Visible = false;
					btnDelete.Visible = false;
					BtnAdd.Visible = false;

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

		}
		#endregion
		void show()
		{
			try
			{
				DataSet dsP = new DataSet();
				string str3 = "select VCHR_NO,SNO,BANK_CD,CHQ_NO,to_char(CHQ_DT,'dd/mm/yyyy')CHQ_DT,ACC_CD,NVL(AMOUNT,0) AMOUNT, BPO_CD from T25_RV_DETAILS where CHQ_NO='" + CNO + "' and CHQ_DT=to_date('" + CDT + "','dd/mm/yyyy') and BANK_CD=" + BCD;
				OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					DisplayAlert("No Record Found!!!");

				}
				else
				{
					lstBank.SelectedValue = dsP.Tables[0].Rows[0]["BANK_CD"].ToString();
					txtEFTNO.Text = dsP.Tables[0].Rows[0]["CHQ_NO"].ToString();
					txtEFTDT.Text = dsP.Tables[0].Rows[0]["CHQ_DT"].ToString();
					txtAmt.Text = dsP.Tables[0].Rows[0]["AMOUNT"].ToString();
					lstACD.SelectedValue = dsP.Tables[0].Rows[0]["ACC_CD"].ToString();
					if (dsP.Tables[0].Rows[0]["BPO_CD"].ToString() != "")
					{
						fill_BPO(dsP.Tables[0].Rows[0]["BPO_CD"].ToString());
					}
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
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			try
			{
				DataSet dsP = new DataSet();
				string str3 = "select T25.VCHR_NO,SNO,T25.BANK_CD,T94.BANK_NAME,T25.CHQ_NO,to_char(T25.CHQ_DT,'dd/mm/yyyy')CHQ_DT,NVL(T25.AMOUNT,0) AMOUNT,NVL(T25.AMOUNT_ADJUSTED,0)AMOUNT_ADJUSTED,NVL(T25.SUSPENSE_AMT,0)SUSPENSE_AMT,NVL2(T25.BPO_CD,V12.BPO_CD||'-'||V12.BPO,'') BPO from T25_RV_DETAILS T25, T94_BANK T94,V12_BILL_PAYING_OFFICER V12 where T25.BANK_CD=T94.BANK_CD and T25.BPO_CD=V12.BPO_CD(+) and substr(VCHR_NO,1,5)='" + Session["Region"] + "9999'";
				if (lstBank.SelectedIndex != 0)
				{
					str3 = str3 + " and T25.BANK_CD=" + lstBank.SelectedValue;
				}
				if (txtEFTNO.Text.Trim() != "")
				{
					str3 = str3 + " and trim(UPPER(CHQ_NO)) like trim(upper('" + txtEFTNO.Text + "%'))";
				}
				if (txtEFTDT.Text.Trim() != "")
				{
					str3 = str3 + " and CHQ_DT=to_date('" + txtEFTDT.Text.Trim() + "','dd/mm/yyyy')";
				}
				if (txtAmt.Text.Trim() != "")
				{
					str3 = str3 + " and AMOUNT='" + txtAmt.Text + "'";
				}
				if (txtBPO.Text.Trim() != "")
				{
					str3 = str3 + " and T25.BPO_CD='" + lstBPO.SelectedValue + "'";
				}


				OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					DisplayAlert("No Record Found!!!");
					grdEFT.Visible = false;
				}
				else
				{
					grdEFT.Visible = true;
					grdEFT.DataSource = dsP;
					grdEFT.DataBind();


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

		protected void btnSave_Click(object sender, System.EventArgs e)
		{

			if (Action == "" || Action == null)
			{

				conn1.Open();
				OracleCommand cmd1 = new OracleCommand("select nvl(max(VCHR_NO||lpad(SNO,4,'0')),0) from T25_RV_DETAILS where substr(VCHR_NO,1,5)='" + Session["Region"].ToString() + 9999 + "'", conn1);
				string vsno = Convert.ToString(cmd1.ExecuteScalar());
				conn1.Close();
				int m1;
				string m = "";
				if (vsno != "0")
				{
					m = vsno.Substring(0, 8);
					m1 = Convert.ToInt16(vsno.Substring(8, 4));

				}
				else
				{
					m = "";
					m1 = 0;
				}
				if (m1 == 9999 || m1 == 0)
				{
					conn1.Open();
					OracleCommand cmd = new OracleCommand("Select lpad(nvl(max(to_number(nvl(substr(VCHR_NO,6,3),0))),0)+1,3,'0') from T24_RV where substr(VCHR_NO,1,5)='" + Session["Region"].ToString() + "9999'", conn1);
					m = Convert.ToString(cmd.ExecuteScalar());
					conn1.Close();

					m = Session["Region"].ToString() + "9999" + m.ToString();
					m1 = 0;
					string myInsertQueryM = "INSERT INTO T24_RV values('" + m + "', '','')";
					OracleCommand myInsertCommandM = new OracleCommand(myInsertQueryM);
					myInsertCommandM.Connection = conn1;
					conn1.Open();
					myInsertCommandM.ExecuteNonQuery();
					conn1.Close();


				}

				m1 = m1 + 1;
				string m11 = m.ToString();
				string myInsertQuery = "INSERT INTO T25_RV_DETAILS(VCHR_NO,SNO,BANK_CD,CHQ_NO,CHQ_DT,AMOUNT,ACC_CD,SUSPENSE_AMT,AMOUNT_ADJUSTED,BPO_CD)values('" + m11 + "'," + m1 + "," + lstBank.SelectedValue + ",'" + txtEFTNO.Text.Trim() + "',to_date('" + txtEFTDT.Text + "','dd/mm/yyyy')," + txtAmt.Text + "," + lstACD.SelectedValue + "," + txtAmt.Text + ",0,'" + lstBPO.SelectedValue + "')";
				OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
				myInsertCommand.Connection = conn1;
				conn1.Open();
				myInsertCommand.ExecuteNonQuery();
				conn1.Close();
				DisplayAlert("Your Record is Saved!!!");



			}
			else if (Action == "M")
			{
				string str11 = "Select NVL(AMOUNT_ADJUSTED,0) from T25_RV_DETAILS where CHQ_NO='" + CNO + "' and CHQ_DT=to_date('" + CDT + "','dd/mm/yyyy') and BANK_CD=" + BCD;
				OracleCommand myUpdateCommand11 = new OracleCommand(str11);
				myUpdateCommand11.Connection = conn1;
				conn1.Open();
				double amtadj = Convert.ToDouble(myUpdateCommand11.ExecuteScalar());
				conn1.Close();

				if (amtadj <= Convert.ToDouble(txtAmt.Text))
				{
					string str = "Update T25_RV_DETAILS set BANK_CD=" + lstBank.SelectedValue + ",CHQ_NO='" + txtEFTNO.Text + "',CHQ_DT=to_date('" + txtEFTDT.Text + "','dd/mm/yyyy'),AMOUNT=" + txtAmt.Text + ",ACC_CD=" + lstACD.SelectedValue + ",SUSPENSE_AMT=" + Convert.ToString(Convert.ToDouble(txtAmt.Text) - amtadj) + ", BPO_CD='" + lstBPO.SelectedValue + "' where CHQ_NO='" + CNO + "' and CHQ_DT=to_date('" + CDT + "','dd/mm/yyyy') and BANK_CD=" + BCD;
					OracleCommand myUpdateCommand = new OracleCommand(str);
					myUpdateCommand.Connection = conn1;
					conn1.Open();
					myUpdateCommand.ExecuteNonQuery();
					conn1.Close();
					DisplayAlert("Your Record is Modified!!!");

				}
				else
				{
					DisplayAlert("The amount already adjusted against this EFT is more than the amount You are entering!!!");
				}

			}
		}

		protected void BtnAdd_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("EFT.aspx");
		}

		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			//			int m=0;
			try
			{
				conn1.Open();
				OracleCommand cmd = new OracleCommand("Select count(*) from T26_CHEQUE_POSTING where CHQ_NO='" + CNO + "' and CHQ_DT=to_date('" + CDT + "','dd/mm/yyyy') and BANK_CD=" + BCD, conn1);
				int post = Convert.ToInt16(cmd.ExecuteScalar());
				conn1.Close();

				if (post == 0)
				{
					string myDeleteQuery = "Delete T25_RV_DETAILS  where CHQ_NO='" + CNO + "' and CHQ_DT=to_date('" + CDT + "','dd/mm/yyyy') and BANK_CD=" + BCD;
					OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
					myOracleCommand.Connection = conn1;
					conn1.Open();
					myOracleCommand.ExecuteNonQuery();
					conn1.Close();
					btnDelete.Visible = false;
					DisplayAlert("Your Record Is Deleted!!!");
				}
				else
				{
					DisplayAlert("You Cannot Delete This EFT, B'coz the posting has been done against it!!!");
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
		int fill_BPO(string bpo)
		{
			lstBPO.Items.Clear();
			DataSet dsP = new DataSet();
			string str1 = "";
			str1 = "select B.BPO_CD,(B.BPO_CD||'-'||B.BPO_NAME||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)||'/'||B.BPO_RLY) BPO_NAME from T12_BILL_PAYING_OFFICER B,T03_CITY C where B.BPO_CITY_CD=C.CITY_CD and (trim(upper(B.BPO_CD))=upper('" + bpo.Trim() + "') or trim(upper(B.BPO_RLY)) LIKE upper('" + bpo.Trim() + "%')) ORDER BY BPO_NAME";

			OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
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
					lst.Text = dsP.Tables[0].Rows[i]["BPO_NAME"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["BPO_CD"].ToString();
					lstBPO.Items.Add(lst);
				}
				lstBPO.Visible = true;
				lstBPO.SelectedIndex = 0;
				txtBPO.Text = lstBPO.SelectedValue;
				ecode = 2;
				return (ecode);

			}

		}
		protected void btnFC_List_Click(object sender, System.EventArgs e)
		{
			try
			{
				lstBPO.Visible = true;
				int a = fill_BPO(txtBPO.Text);
				if (a == 1)
				{
					lstBPO.Visible = false;
					DisplayAlert("No BPO Found!!!");
					rbs.SetFocus(txtBPO);
				}
				else
				{
					rbs.SetFocus(lstBPO);
				}

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str2 = str.Replace("\n", "");
				Response.Redirect("Error_Form.aspx?err=" + str2);

			}
			finally
			{
				conn1.Close();
			}
		}

		protected void lstBPO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtBPO.Text = lstBPO.SelectedValue;

		}
	}
}