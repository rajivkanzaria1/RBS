using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.CaseNoBPOforAdvancedCheque
{
	public partial class CaseNoBPOforAdvancedCheque : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		DataSet dsP = new DataSet();
		public string VNO, Action;
		int SNO;
		protected System.Web.UI.WebControls.TextBox txtDtOfReciept;
		protected System.Web.UI.WebControls.TextBox txtBKNO;
		int ecode = 0;

		void show1()
		{
			DataSet dsP = new DataSet();
			string str3 = "select SNO,ACC_CD,AMOUNT,NVL(AMOUNT_ADJUSTED,0)AMOUNT_ADJUSTED,BPO_CD,BANK_CD,CHQ_NO,to_char(CHQ_DT,'dd/mm/yyyy')CHQ_DT,NARRATION,SAMPLE_NO,CASE_NO from T25_RV_DETAILS where VCHR_NO='" + VNO + "' AND SNO=" + SNO;
			OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			lstACD.SelectedValue = dsP.Tables[0].Rows[0]["ACC_CD"].ToString();
			if (lstACD.SelectedValue == "2201")
			{
				lblType.Text = "R";
			}
			else if (lstACD.SelectedValue == "2202")
			{
				lblType.Text = "F";
			}
			else if (lstACD.SelectedValue == "2203")
			{
				lblType.Text = "U";
			}
			else if (lstACD.SelectedValue == "2204")
			{
				lblType.Text = "P";
			}
			else if (lstACD.SelectedValue == "2205")
			{
				lblType.Text = "S";
			}
			else
			{
				lblType.Text = "";
			}

			txtNarrat.Text = dsP.Tables[0].Rows[0]["NARRATION"].ToString();
			txtCNO.Text = dsP.Tables[0].Rows[0]["CHQ_NO"].ToString();
			lblCNO.Text = txtCNO.Text;
			txtCDT.Text = dsP.Tables[0].Rows[0]["CHQ_DT"].ToString();
			lblCDT.Text = txtCDT.Text.Trim();
			txtAmt.Text = dsP.Tables[0].Rows[0]["AMOUNT"].ToString();
			txtSNo.Text = dsP.Tables[0].Rows[0]["SAMPLE_NO"].ToString();
			lstBank1.SelectedValue = dsP.Tables[0].Rows[0]["BANK_CD"].ToString();
			txtCSNO.Text = dsP.Tables[0].Rows[0]["CASE_NO"].ToString();
			if (dsP.Tables[0].Rows[0]["BPO_CD"].ToString() != "")
			{
				fill_BPO(dsP.Tables[0].Rows[0]["BPO_CD"].ToString());
			}

			txtCNO.Visible = false;
			lstBank1.Enabled = false;
			lstACD.Enabled = false;
			txtAmt.Enabled = false;
			txtSNo.Enabled = false;
			txtCDT.Visible = false;
			txtNarrat.Enabled = false;

			conn1.Close();


		}
		protected void Page_Load(object sender, System.EventArgs e)
		{

			btnFC_List.Attributes.Add("OnClick", "JavaScript:validate1();");
			btnSave1.Attributes.Add("OnClick", "JavaScript:validate();");
			btnSearch.Attributes.Add("OnClick", "JavaScript:validate2();");

			if (Convert.ToString(Request.Params["VOUCHER_NO"]) == "" || Convert.ToString(Request.Params["VOUCHER_NO"]) == null)
			{
				VNO = "";
				Action = Convert.ToString(Request.Params["Action"]); ;
			}
			else if (Convert.ToString(Request.Params["VOUCHER_NO"]) != "" && Convert.ToString(Request.Params["Action"]) != "")
			{
				VNO = Convert.ToString(Request.Params["VOUCHER_NO"]);
				Action = Convert.ToString(Request.Params["Action"]);

				if (Request.Params["SRNO"] == "" || Request.Params["SNO"] == null)
				{
					SNO = 0;
				}
				else
				{
					SNO = Convert.ToInt32(Request.Params["SNO"]);


				}



			}
			if (Session["Role_CD"].ToString() == "4")
			{
				btnSave1.Visible = false;

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
				string stra2 = "select BANK_CD,BANK_NAME from T94_BANK order by BANK_NAME";
				OracleDataAdapter da2 = new OracleDataAdapter(stra2, conn1);
				OracleCommand myOracleCommand2 = new OracleCommand(stra2, conn1);
				//ListItem lst; 
				conn1.Open();
				da2.SelectCommand = myOracleCommand2;
				da2.Fill(dsP2, "Table");
				lstBank1.DataValueField = "BANK_CD";
				lstBank1.DataTextField = "BANK_NAME";
				lstBank1.DataSource = dsP2;
				lstBank1.DataBind();
				conn1.Close();

				if (Convert.ToString(Request.Params["VOUCHER_NO"]) != "" && Convert.ToString(Request.Params["Action"]) != "")
				{
					if (Request.Params["SNO"] == "" || Request.Params["SNO"] == null)
					{
						SNO = 0;

					}
					else
					{
						SNO = Convert.ToInt32(Request.Params["SNO"]);
						show1();

					}


				}

				if (Action == "M" && SNO != 0)
				{
					Panel1.Visible = true;
					Panel2.Visible = false;

				}
				else
				{
					Panel1.Visible = false;
					Panel2.Visible = true;
					//					fillgrid();
				}


				conn1.Close();

			}


		}

		string dateconcate(string dt)
		{
			string myYear, myMonth, myDay;

			myYear = dt.Substring(8, 2);
			myMonth = dt.Substring(3, 2);
			myDay = dt.Substring(0, 2);
			string dt1 = myYear + myMonth + myDay;
			return (dt1);
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


		void fillgrid(string str1)
		{
			try
			{
				//string str1 = "select R.VCHR_NO,R.SNO,A.ACC_DESC,R.AMOUNT,(B.BPO_NAME||'/'||B.BPO_ADD||'/'||B.BPO_RLY)BPO_NAME,R.CHQ_NO,to_char(R.CHQ_DT,'dd/mm/yyyy')CHQ_DT,R.NARRATION,R.SAMPLE_NO,D.BANK_NAME from T25_RV_DETAILS R, T95_ACCOUNT_CODES A, T12_BILL_PAYING_OFFICER B,T94_BANK D where R.ACC_CD=A.ACC_CD(+) AND R.BPO_CD=B.BPO_CD(+) and R.BANK_CD=D.BANK_CD AND VCHR_NO= '" + VNO + "'";
				//					string str1 = "select R.VCHR_NO,R.SNO,(R.ACC_CD||'-'||A.ACC_DESC)ACC_DESC,R.AMOUNT,NVL2(R.BPO_CD,B.BPO_CD||'-'||(B.BPO_NAME||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)||'/'||B.BPO_RLY),'')BPO_NAME,R.CHQ_NO,to_char(R.CHQ_DT,'dd/mm/yyyy')CHQ_DT,R.NARRATION,R.CASE_NO,D.BANK_NAME from T25_RV_DETAILS R, T95_ACCOUNT_CODES A, T12_BILL_PAYING_OFFICER B,T94_BANK D,T03_CITY C where R.ACC_CD=A.ACC_CD(+) AND R.BPO_CD=B.BPO_CD(+) and R.BANK_CD=D.BANK_CD AND B.BPO_CITY_CD=C.CITY_CD(+) and substr(VCHR_NO,1,1)='"+Session["Region"]+"' AND (trim(R.BPO_CD) is null or trim(R.CASE_NO) is null) order by R.CHQ_DT,CHQ_NO";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdVDt.Visible = false;
				}
				else
				{
					grdVDt.Visible = true;
					grdVDt.DataSource = dsP;
					grdVDt.DataBind();
				}
				conn1.Close();

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str2 = str.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str2));
			}
			finally
			{
				conn1.Close();
			}
		}
		protected void btnSave1_Click(object sender, System.EventArgs e)
		{
			if (lstBPO.Visible == true)
			{


				string str = "Update T25_RV_DETAILS set BPO_CD='" + lstBPO.SelectedValue + "',CASE_NO='" + txtCSNO.Text + "',BPO_TYPE='" + lblType.Text + "' where VCHR_NO= '" + VNO + "' AND SNO=" + SNO;
				OracleCommand myUpdateCommand = new OracleCommand(str);
				myUpdateCommand.Connection = conn1;
				conn1.Open();
				myUpdateCommand.ExecuteNonQuery();
				conn1.Close();
				Response.Redirect("CaseNoBPOforAdvancedCheque.aspx");

			}
			else
			{
				DisplayAlert("Plz Fill the CASE NO. 1st and then Click on the Select BPO and then Select The BPO from the List!!!");
			}

		}
		int ChkCSNO()
		{
			if (txtCSNO.Visible == true)
			{
				//string str = "select count(*) from T14_PO_BPO WHERE CASE_NO='"+txtCSNO.Text+"' AND BPO='"+lstBPO.SelectedValue+"'"; 
				string str = "select P.CASE_NO, B.BPO_CD,V.VEND_NAME from T13_PO_MASTER P,T14_PO_BPO B, T05_VENDOR V WHERE P.CASE_NO=B.CASE_NO(+) and P.VEND_CD=V.VEND_CD and P.CASE_NO='" + txtCSNO.Text + "' group by P.CASE_NO,B.BPO_CD,V.VEND_NAME";
				OracleCommand cmd = new OracleCommand(str, conn1);
				conn1.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				if (reader.HasRows == false)
				{
					DisplayAlert("Invalid Case No.!!!");
					conn1.Close();
					return (0);

				}
				else
				{


					lstBPO.Items.Clear();
					DataSet dsP = new DataSet();
					string str1 = "select Distinct(P.BPO_CD) BPO_CD,(B.BPO_NAME||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)||'/'||B.BPO_RLY) BPO_NAME from T12_BILL_PAYING_OFFICER B,T14_PO_BPO P, T03_CITY C where P.BPO_CD=B.BPO_CD AND B.BPO_CITY_CD=C.CITY_CD AND P.CASE_NO=upper('" + txtCSNO.Text + "') ORDER BY BPO_NAME";
					OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
					OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
					ListItem lst;
					da.SelectCommand = myOracleCommand;
					da.Fill(dsP, "Table");
					if (dsP.Tables[0].Rows.Count == 0)
					{
						lstBPO.Visible = false;
						txtBPO.Text = "";
						DisplayAlert("Their is No BPO Present For the given Case No,To enter BPO goto PO Update.");
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
						txtBPO.Visible = false;
						rbs.SetFocus(lstBPO);
					}
					conn1.Close();
					return (1);


				}
			}
			else
				return (2);
		}




		int fill_BPO(string bpo)
		{
			lstBPO.Items.Clear();
			DataSet dsP = new DataSet();
			string str1 = "";
			if (lstACD.SelectedValue == "2201" || lstACD.SelectedValue == "2202" || lstACD.SelectedValue == "2203" || lstACD.SelectedValue == "2204" || lstACD.SelectedValue == "2205")
			{
				str1 = "select B.BPO_CD,(B.BPO_NAME||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)||'/'||B.BPO_RLY) BPO_NAME from T12_BILL_PAYING_OFFICER B, T03_CITY C where B.BPO_CITY_CD = C.CITY_CD and (trim(upper(B.BPO_CD))=upper('" + bpo.Trim() + "') or trim(upper(B.BPO_RLY)) LIKE upper('" + bpo.Trim() + "%')) and B.BPO_TYPE='" + lblType.Text + "' ORDER BY BPO_NAME";
			}
			else
			{
				str1 = "select B.BPO_CD,(B.BPO_NAME||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)||'/'||B.BPO_RLY) BPO_NAME from T12_BILL_PAYING_OFFICER B,T03_CITY C where B.BPO_CITY_CD=C.CITY_CD and (trim(upper(B.BPO_CD))=upper('" + bpo.Trim() + "') or trim(upper(B.BPO_RLY)) LIKE upper('" + bpo.Trim() + "%')) ORDER BY BPO_NAME";
			}
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

				if (lstACD.SelectedValue == "2709" || lstACD.SelectedValue == "2210" || lstACD.SelectedValue == "2212")
				{
					ChkCSNO();
				}
				else
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
						Label2.Visible = false;
					}
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
			rbs.SetFocus(txtNarrat);
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{


			if (Session["Role"].ToString() == "General User")
			{
				Response.Redirect("MainForm.aspx");
			}
			else if (Session["Role"].ToString() == "Insp. Engineer")
			{
				Response.Redirect("MainForm2.aspx");
			}
			else
			{
				Response.Redirect("MainForm.aspx");
			}

		}


		protected void lstACD_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtBPO.Text = "";
			lstBPO.Items.Clear();
			if (lstACD.SelectedValue == "2709" || lstACD.SelectedValue == "2210" || lstACD.SelectedValue == "2212")
			{
				Label12.Visible = true;
				txtCSNO.Visible = true;
				rbs.SetFocus(txtCSNO);
				Label9.Visible = true;
				txtBPO.Visible = false;
				lstBPO.Visible = false;
				btnFC_List.Visible = true;
				lblType.Text = "";
			}
			else if (lstACD.SelectedValue == "2201" || lstACD.SelectedValue == "2202" || lstACD.SelectedValue == "2203" || lstACD.SelectedValue == "2204" || lstACD.SelectedValue == "2205")
			{
				Label12.Visible = false;
				txtCSNO.Visible = false;
				txtCSNO.Text = "";
				Label9.Visible = true;
				txtBPO.Visible = true;
				lstBPO.Visible = false;
				btnFC_List.Visible = true;
				if (lstACD.SelectedValue == "2201")
				{
					lblType.Text = "R";
				}
				else if (lstACD.SelectedValue == "2202")
				{
					lblType.Text = "F";
				}
				else if (lstACD.SelectedValue == "2203")
				{
					lblType.Text = "U";
				}
				else if (lstACD.SelectedValue == "2204")
				{
					lblType.Text = "P";
				}
				else if (lstACD.SelectedValue == "2205")
				{
					lblType.Text = "S";
				}
				rbs.SetFocus(txtBPO);
			}
			else
			{
				Label12.Visible = false;
				txtCSNO.Visible = false;
				txtCSNO.Text = "";
				Label9.Visible = false;
				//txtBPO.Text="";
				txtBPO.Visible = false;
				//lstBPO.Items.Clear();
				lstBPO.Visible = false;
				btnFC_List.Visible = false;
				rbs.SetFocus(txtNarrat);
				lblType.Text = "";

			}


		}

		protected void lstACD_PreRender(object sender, System.EventArgs e)
		{
			if (lstACD.SelectedValue == "2709" || lstACD.SelectedValue == "2210" || lstACD.SelectedValue == "2212")

			{
				Label12.Visible = true;
				txtCSNO.Visible = true;
				txtBPO.Visible = false;
			}
			else
			{
				Label12.Visible = false;
				txtCSNO.Visible = false;
				txtCSNO.Text = "";
			}
		}

		protected void txtCSNO_PreRender(object sender, System.EventArgs e)
		{
			ChkCSNO();
		}

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			string str1 = "";
			if (btnPChq.Checked == true)
			{
				str1 = "select R.VCHR_NO,R.SNO,(R.ACC_CD||'-'||A.ACC_DESC)ACC_DESC,R.AMOUNT,NVL2(R.BPO_CD,B.BPO_CD||'-'||(B.BPO_NAME||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)||'/'||B.BPO_RLY),'')BPO_NAME,R.CHQ_NO,to_char(R.CHQ_DT,'dd/mm/yyyy')CHQ_DT,R.NARRATION,R.CASE_NO,D.BANK_NAME from T25_RV_DETAILS R, T95_ACCOUNT_CODES A, T12_BILL_PAYING_OFFICER B,T94_BANK D,T03_CITY C where R.ACC_CD=A.ACC_CD(+) AND R.BPO_CD=B.BPO_CD(+) and R.BANK_CD=D.BANK_CD AND B.BPO_CITY_CD=C.CITY_CD(+) and substr(VCHR_NO,1,1)='" + Session["Region"] + "' AND (trim(R.BPO_CD) is null or trim(R.CASE_NO) is null) and trim(UPPER(R.CHQ_NO))like trim(upper('" + txtCHQ_NO_SEARCH.Text.Trim() + "%')) order by R.CHQ_DT,CHQ_NO";
			}
			else if (btnAcc_CD.Checked == true)
			{
				if (lstACC_CD_SEARCH.SelectedValue == "2709")
				{
					str1 = "select R.VCHR_NO,R.SNO,(R.ACC_CD||'-'||A.ACC_DESC)ACC_DESC,R.AMOUNT,NVL2(R.BPO_CD,B.BPO_CD||'-'||(B.BPO_NAME||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)||'/'||B.BPO_RLY),'')BPO_NAME,R.CHQ_NO,to_char(R.CHQ_DT,'dd/mm/yyyy')CHQ_DT,R.NARRATION,R.CASE_NO,D.BANK_NAME from T25_RV_DETAILS R, T95_ACCOUNT_CODES A, T12_BILL_PAYING_OFFICER B,T94_BANK D,T03_CITY C where R.ACC_CD=A.ACC_CD(+) AND R.BPO_CD=B.BPO_CD(+) and R.BANK_CD=D.BANK_CD AND B.BPO_CITY_CD=C.CITY_CD(+) and substr(VCHR_NO,1,1)='" + Session["Region"] + "' AND R.ACC_CD=2709 and (trim(R.BPO_CD) is null or trim(R.CASE_NO) is null) order by R.CHQ_DT,CHQ_NO";
				}
				else if (lstACC_CD_SEARCH.SelectedValue == "O")
				{
					str1 = "select R.VCHR_NO,R.SNO,(R.ACC_CD||'-'||A.ACC_DESC)ACC_DESC,R.AMOUNT,NVL2(R.BPO_CD,B.BPO_CD||'-'||(B.BPO_NAME||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)||'/'||B.BPO_RLY),'')BPO_NAME,R.CHQ_NO,to_char(R.CHQ_DT,'dd/mm/yyyy')CHQ_DT,R.NARRATION,R.CASE_NO,D.BANK_NAME from T25_RV_DETAILS R, T95_ACCOUNT_CODES A, T12_BILL_PAYING_OFFICER B,T94_BANK D,T03_CITY C where R.ACC_CD=A.ACC_CD(+) AND R.BPO_CD=B.BPO_CD(+) and R.BANK_CD=D.BANK_CD AND B.BPO_CITY_CD=C.CITY_CD(+) and substr(VCHR_NO,1,1)='" + Session["Region"] + "' AND R.ACC_CD<>2709 and (trim(R.BPO_CD) is null) order by R.CHQ_DT,CHQ_NO";
				}
				else
				{
					str1 = "select R.VCHR_NO,R.SNO,(R.ACC_CD||'-'||A.ACC_DESC)ACC_DESC,R.AMOUNT,NVL2(R.BPO_CD,B.BPO_CD||'-'||(B.BPO_NAME||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)||'/'||B.BPO_RLY),'')BPO_NAME,R.CHQ_NO,to_char(R.CHQ_DT,'dd/mm/yyyy')CHQ_DT,R.NARRATION,R.CASE_NO,D.BANK_NAME from T25_RV_DETAILS R, T95_ACCOUNT_CODES A, T12_BILL_PAYING_OFFICER B,T94_BANK D,T03_CITY C where R.ACC_CD=A.ACC_CD(+) AND R.BPO_CD=B.BPO_CD(+) and R.BANK_CD=D.BANK_CD AND B.BPO_CITY_CD=C.CITY_CD(+) and substr(VCHR_NO,1,1)='" + Session["Region"] + "' AND ((R.ACC_CD=2709 and (trim(R.BPO_CD) is null or trim(R.CASE_NO) is null)) or (R.ACC_CD<>2709 and (trim(R.BPO_CD) is null))) order by R.CHQ_DT,CHQ_NO";
				}

			}
			fillgrid(str1);
		}







	}
}