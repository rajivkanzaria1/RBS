using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.IE_NC_Edit_Form
{
	public partial class IE_NC_Edit_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		DataSet dsP = new DataSet();
		protected System.Web.UI.WebControls.TextBox txtRdt;
		string BNO, SNO, CSNO, NCNO;
		protected System.Web.UI.WebControls.TextBox txtCSNO;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnAdd.Attributes.Add("OnClick", "JavaScript:validate2();");
			btnSearch.Attributes.Add("OnClick", "JavaScript:validate();");
			btnMod.Attributes.Add("OnClick", "JavaScript:validate3();");
			btnSubmit.Attributes.Add("OnClick", "JavaScript:validate1();");
			if (!(IsPostBack))
			{
				if (Convert.ToString(Request.Params["NC_NO"]) != "")
				{
					NCNO = Convert.ToString(Request.Params["NC_NO"]);
					BNO = "";
					SNO = "";
					CSNO = "";
					txtNCR_NO.Text = NCNO;
				}
				else if (Convert.ToString(Request.Params["BK_NO"]) != "" && Convert.ToString(Request.Params["SET_NO"]) != null)
				{
					BNO = Convert.ToString(Request.Params["BK_NO"]);
					SNO = Convert.ToString(Request.Params["SET_NO"]);
					CSNO = Convert.ToString(Request.Params["CASE_NO"]);
					txtBKNo.Text = BNO;
					txtSetNo.Text = SNO;
					txtCaseNo.Text = CSNO;

				}
				else if (Convert.ToString(Request.Params["BK_NO"]) == "" && Convert.ToString(Request.Params["SET_NO"]) == "")
				{
					txtCaseNo.Text = Convert.ToString(Request.Params["CASE_NO"]);
					txtRdt.Text = Convert.ToString(Request.Params["CALL_RECV_DT"]);
					txtCSNO.Text = Convert.ToString(Request.Params["CALL_SNO"]);
				}
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				DataSet dsP1 = new DataSet();
				string str3 = "select IE_CD, IE_NAME from T09_IE where IE_REGION='" + Session["REGION"] + "' order by IE_NAME ";
				OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
				ListItem lst3;
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP1, "Table");
				for (int i = 0; i <= dsP1.Tables[0].Rows.Count - 1; i++)
				{
					lst3 = new ListItem();
					lst3.Text = dsP1.Tables[0].Rows[i]["IE_NAME"].ToString();
					lst3.Value = dsP1.Tables[0].Rows[i]["IE_CD"].ToString();
					lstIE.Items.Add(lst3);
				}
				conn1.Close();
				conn1.Dispose();
				radio_changed();
				//				if(Session["Role_CD"].ToString() == "1")
				//				{
				//					btnDelete.Visible=true;
				//				}
				//				else if(Session["Role_CD"].ToString() == "4")
				//				{
				//					btnDelete.Visible=false;
				//					btnAdd.Visible=false;
				//					btnMod.Text="View";
				//					btnChangeCon.Visible=false;
				//				
				//				}
				//				else
				//				{
				//					btnDelete.Visible=false;
				//				}
				Label8.Visible = false;

				if (Session["Uname"].ToString() != "")
				{
					btnAdd.Visible = true;
				}
				else if (Session["IE_CD"].ToString() != "")
				{
					btnAdd.Visible = false;
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

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			string check = match();
			if (check == "2")
			{
				Response.Redirect("IE_NC_Form.aspx?Action=A&Case_No=" + txtCaseNo.Text.Trim() + "&BK_NO=" + txtBKNo.Text.Trim() + "&SET_NO=" + txtSetNo.Text);
			}
			//			else
			//			{
			//				DisplayAlert("No Record Present for the Given Case No, Call Date and Call SNo in Call Master!!!");
			//			}
		}

		protected void btnMod_Click(object sender, System.EventArgs e)
		{
			string check = match1();
			if (check == "2")
			{
				Response.Redirect("IE_NC_Form.aspx?Action=M&NC_NO=" + txtNCR_NO.Text.Trim());
			}
			//			else
			//			{
			//				DisplayAlert("No Record Present for Given Book No and Set No in IC Master!!! ");
			//			}

		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			string check = match1();
			if (check == "2")
			{
				string bkno = txtBKNo.Text.Trim();
				string sno = txtSetNo.Text.Trim();
				Response.Redirect("Inspection_Certificate_Form.aspx?Action=D&BK_NO=" + bkno + "&SET_NO=" + sno);
			}
			//			else
			//			{
			//				DisplayAlert("No Record Present for Given Book No and Set No in IC Master!!! ");
			//			}

		}
		public string match()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			OracleCommand cmd = new OracleCommand("select substr(CASE_NO,1,1) from T20_IC where CASE_NO='" + txtCaseNo.Text.Trim() + "' and BK_NO='" + txtBKNo.Text.Trim() + "' and SET_NO='" + txtSetNo.Text.Trim() + "'", conn1);
			string test = "";
			conn1.Open();
			test = Convert.ToString(cmd.ExecuteScalar());
			conn1.Close();
			conn1.Dispose();
			if (test == "\0" || test == "")
			{
				test = "0";
				DisplayAlert("No Record Present for the Given Case No, BK NO and Call SET NO in Call Master!!!");
			}
			else if (test == Session["Region"].ToString())
			{
				test = "2";

			}
			else
			{
				test = "1";
				DisplayAlert("You are not Authorised to Add NC Data For Other Regions.!!! ");
			}

			return test;

		}

		public string match1()
		{
			//OracleCommand cmd=new OracleCommand("select count(BK_NO) from T20_IC where BK_NO='"+txtBKNo.Text.Trim()+"' and SET_NO='"+txtSetNo.Text.Trim()+"'",conn1);
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			OracleCommand cmd = new OracleCommand("select substr(CASE_NO,1,1)REGION_CODE from T41_NC_MASTER where NC_NO='" + txtNCR_NO.Text.Trim() + "' and (REGION_CODE)='" + Session["Region"] + "'", conn1);
			string test = "";
			conn1.Open();
			test = Convert.ToString(cmd.ExecuteScalar());
			conn1.Close();
			conn1.Dispose();
			if (test == "\0" || test == "")
			{
				test = "0";
				DisplayAlert("No Record Present for Given Book No and Set No in IC Master!!! ");
			}
			else if (test == Session["Region"].ToString())
			{
				test = "2";

			}
			else
			{
				test = "1";
				DisplayAlert("You are not Authorised to Update/Delete NC Data For Other Regions.!!! ");
			}
			return test;
		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{



				string str1 = "Select T41.NC_NO NC_NO,T20.CASE_NO CASE_NO, T20.BK_NO BK_NO,T20.SET_NO SET_NO, to_char(T17.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DATE,T17.CALL_SNO CALL_SNO,T09.IE_SNAME IE_SNAME,(T06.CONSIGNEE_CD||'-'||nvl2(trim(T06.CONSIGNEE_DESIG),trim(T06.CONSIGNEE_DESIG)||'/','')||nvl2(trim(T06.CONSIGNEE_DEPT),trim(T06.CONSIGNEE_DEPT)||'/','')||nvl2(trim(T06.CONSIGNEE_FIRM),trim(T06.CONSIGNEE_FIRM)||'/','')||NVL2(trim(T06.CONSIGNEE_ADD1),trim(T06.CONSIGNEE_ADD1)||'/','')||NVL2(trim(T03.LOCATION),trim(T03.LOCATION)||' : '||trim(T03.CITY),trim(T03.CITY))) CONSIGNEE " +
					"From T17_CALL_REGISTER T17,T20_IC T20, T09_IE T09,T06_CONSIGNEE T06, T03_CITY T03, T41_NC_MASTER T41 " +
					"Where T20.CASE_NO=T17.CASE_NO AND T20.CALL_RECV_DT=T17.CALL_RECV_DT AND T20.CALL_SNO=T17.CALL_SNO AND " +
					"T17.IE_CD=T09.IE_CD AND T20.CONSIGNEE_CD=T06.CONSIGNEE_CD AND T06.CONSIGNEE_CITY=T03.CITY_CD and T20.BK_NO=T41.BK_NO and T20.SET_NO =T41.SET_NO and T20.CONSIGNEE_CD=T41.CONSIGNEE_CD " +
					"and T17.REGION_CODE='" + Session["Region"].ToString() + "'";


				if (txtCaseNo1.Text.Trim() != "")
				{

					str1 = str1 + " and upper(T17.CASE_NO)=upper('" + txtCaseNo1.Text.Trim() + "')";
				}

				if (txtNCR_NO.Text.Trim() != "")
				{

					str1 = str1 + " and upper(T41.NC_NO)=upper('" + txtNCR_NO.Text.Trim() + "')";
				}


				str1 = str1 + " order by CALL_RECV_DATE,CASE_NO,BK_NO,SET_NO";

				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{

					grdIC.Visible = false;
					DisplayAlert("No NCR Present!!!");
					//Label4.Visible=true;
				}
				else
				{
					grdIC.Visible = true;
					grdIC.DataSource = dsP;
					grdIC.DataBind();
					Label8.Visible = true;
					grdIC.Columns[1].Visible = false;
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

		private void btnChangeCon_Click(object sender, System.EventArgs e)
		{
			string check = match1();
			if (check == "2")
			{
				string bkno = txtBKNo.Text.Trim();
				string sno = txtSetNo.Text.Trim();
				Response.Redirect("ChangeT20_Consignee.aspx?Action=M&BK_NO=" + bkno + "&SET_NO=" + sno);
			}
		}

		protected void rdbCSNO_CheckedChanged(object sender, System.EventArgs e)
		{
			radio_changed();
		}

		void radio_changed()
		{
			if (rdbCSNO.Checked == true)
			{
				Label6.Visible = true;
				Label4.Visible = true;
				Label5.Visible = true;
				txtCaseNo.Visible = true;
				txtBKNo.Visible = true;
				txtSetNo.Visible = true;
				lblIE.Visible = false;
				Label11.Visible = false;
				Label12.Visible = false;
				frmDt.Visible = false;
				toDt.Visible = false;
				lstIE.Visible = false;
				btnAdd.Visible = true;
				btnSubmit.Visible = false;
			}
			else if (rdbIE.Checked == true)
			{
				Label6.Visible = false;
				Label4.Visible = false;
				Label5.Visible = false;
				txtCaseNo.Visible = false;
				txtBKNo.Visible = false;
				txtSetNo.Visible = false;
				lblIE.Visible = true;
				Label11.Visible = true;
				Label12.Visible = true;
				frmDt.Visible = true;
				toDt.Visible = true;
				lstIE.Visible = true;
				btnAdd.Visible = false;
				btnSubmit.Visible = true;
			}

		}

		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{



				string str1 = "Select T41.NC_NO NC_NO,T20.CASE_NO CASE_NO, T20.BK_NO BK_NO,T20.SET_NO SET_NO, to_char(T17.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DATE,T17.CALL_SNO CALL_SNO,T09.IE_SNAME IE_SNAME,(T06.CONSIGNEE_CD||'-'||nvl2(trim(T06.CONSIGNEE_DESIG),trim(T06.CONSIGNEE_DESIG)||'/','')||nvl2(trim(T06.CONSIGNEE_DEPT),trim(T06.CONSIGNEE_DEPT)||'/','')||nvl2(trim(T06.CONSIGNEE_FIRM),trim(T06.CONSIGNEE_FIRM)||'/','')||NVL2(trim(T06.CONSIGNEE_ADD1),trim(T06.CONSIGNEE_ADD1)||'/','')||NVL2(trim(T03.LOCATION),trim(T03.LOCATION)||' : '||trim(T03.CITY),trim(T03.CITY))) CONSIGNEE " +
					"From T17_CALL_REGISTER T17,T20_IC T20, T09_IE T09,T06_CONSIGNEE T06, T03_CITY T03, T41_NC_MASTER T41 " +
					"Where T20.CASE_NO=T17.CASE_NO AND T20.CALL_RECV_DT=T17.CALL_RECV_DT AND T20.CALL_SNO=T17.CALL_SNO AND " +
					"T17.IE_CD=T09.IE_CD AND T20.CONSIGNEE_CD=T06.CONSIGNEE_CD AND T06.CONSIGNEE_CITY=T03.CITY_CD and T20.BK_NO=T41.BK_NO(+) and T20.SET_NO =T41.SET_NO(+) and T20.CONSIGNEE_CD=T41.CONSIGNEE_CD(+) " +
					"and T17.REGION_CODE='" + Session["Region"].ToString() + "'";



				str1 = str1 + " and upper(T17.IE_CD)=" + lstIE.SelectedValue;


				str1 = str1 + " and (T17.CALL_RECV_DT between to_date('" + frmDt.Text + "','dd/mm/yyyy') and to_date('" + toDt.Text + "','dd/mm/yyyy'))";



				str1 = str1 + " order by CALL_RECV_DATE,CASE_NO";

				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{

					grdIC.Visible = false;
					DisplayAlert("No Call Found!!!");
					//Label4.Visible=true;
				}
				else
				{
					grdIC.Visible = true;
					grdIC.DataSource = dsP;
					grdIC.DataBind();
					Label8.Visible = true;
					grdIC.Columns[0].Visible = false;
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