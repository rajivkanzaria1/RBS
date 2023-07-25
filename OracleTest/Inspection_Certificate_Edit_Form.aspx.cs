using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS
{
    public partial class Inspection_Certificate_Edit_Form : System.Web.UI.Page
    {
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		DataSet dsP = new DataSet();
		string BNO, SNO;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnAdd.Attributes.Add("OnClick", "JavaScript:validate1();");
			btnMod.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelete.Attributes.Add("OnClick", "JavaScript:validate();");
			btnSearch.Attributes.Add("OnClick", "JavaScript:validate3();");
			btnChangeCon.Attributes.Add("OnClick", "JavaScript:validate();");

			if (!(IsPostBack))
			{
				if (Convert.ToString(Request.Params["BK_NO"]) == "" && Convert.ToString(Request.Params["SET_NO"]) == "" && Convert.ToString(Request.Params["CASE_NO"]) == "")
				{
					BNO = "";
					SNO = "";
				}
				else if (Convert.ToString(Request.Params["BK_NO"]) != "" && Convert.ToString(Request.Params["SET_NO"]) != null)
				{
					BNO = Convert.ToString(Request.Params["BK_NO"]);
					SNO = Convert.ToString(Request.Params["SET_NO"]);
					txtBKNo.Text = BNO;
					txtSetNo.Text = SNO;

				}
				else if (Convert.ToString(Request.Params["BK_NO"]) == "" && Convert.ToString(Request.Params["SET_NO"]) == "")
				{
					txtCaseNo.Text = Convert.ToString(Request.Params["CASE_NO"]);
					txtRdt.Text = Convert.ToString(Request.Params["CALL_RECV_DT"]);
					txtCSNO.Text = Convert.ToString(Request.Params["CALL_SNO"]);
				}
				if (Session["Role_CD"].ToString() == "1")
				{
					btnDelete.Visible = true;
				}
				else if (Session["Role_CD"].ToString() == "4")
				{
					btnDelete.Visible = false;
					btnAdd.Visible = false;
					btnMod.Text = "View";
					btnChangeCon.Visible = false;

				}
				else
				{
					btnDelete.Visible = false;
				}
				Label8.Visible = false;
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
				string code = txtCaseNo.Text.Trim();
				string dt = txtRdt.Text.Trim();
				string csno = txtCSNO.Text.Trim();
				Response.Redirect("Inspection_Certificate_Form.aspx?Action=A&Case_No=" + code + "&CALL_RECV_DT=" + dt + "&CALL_SNO=" + csno);
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
				string bkno = txtBKNo.Text.Trim();
				string sno = txtSetNo.Text.Trim();
				Response.Redirect("Inspection_Certificate_Form.aspx?Action=M&BK_NO=" + bkno + "&SET_NO=" + sno);
			}
			//			else
			//			{
			//				DisplayAlert("No Record Present for Given Book No and Set No in IC Master!!! ");
			//			}

		}

		protected void btnDelete_Click(object sender, System.EventArgs e)
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
			OracleCommand cmd = new OracleCommand("select REGION_CODE from T17_CALL_REGISTER where CASE_NO='" + txtCaseNo.Text.Trim() + "' and CALL_RECV_DT=to_date('" + txtRdt.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + txtCSNO.Text.Trim(), conn1);
			string test = "";
			conn1.Open();
			test = Convert.ToString(cmd.ExecuteScalar());
			conn1.Close();
			if (test == "\0" || test == "")
			{
				test = "0";
				DisplayAlert("No Record Present for the Given Case No, Call Date and Call SNo in Call Master!!!");
			}
			else if (test == Session["Region"].ToString())
			{
				test = "2";

			}
			else
			{
				test = "1";
				DisplayAlert("You are not Authorised to Add IC Data For Other Regions.!!! ");
			}

			return test;

		}

		public string match1()
		{
			//OracleCommand cmd=new OracleCommand("select count(BK_NO) from T20_IC where BK_NO='"+txtBKNo.Text.Trim()+"' and SET_NO='"+txtSetNo.Text.Trim()+"'",conn1);
			OracleCommand cmd = new OracleCommand("select substr(CASE_NO,1,1)REGION_CODE from T20_IC where BK_NO='" + txtBKNo.Text.Trim() + "' and SET_NO='" + txtSetNo.Text.Trim() + "' and substr(CASE_NO,1,1)='" + Session["Region"] + "'", conn1);
			string test = "";
			conn1.Open();
			test = Convert.ToString(cmd.ExecuteScalar());
			conn1.Close();
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
				DisplayAlert("You are not Authorised to Update/Delete IC Data For Other Regions.!!! ");
			}
			return test;
		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			try
			{
				//string str1 = "select IC_NO, CASE_NO, TO_CHAR(CALL_RECV_DT,'dd/mm/yy') CALL_RECV_DT from T20_IC where CASE_NO='"+txtCaseNo.Text.Trim()+"' and CALL_RECV_DT=to_date('"+txtRdt.Text.Trim()+"','dd/mm/yyyy')"; 
				//str1=str1 + " UNION select ('null')IC_NO, CASE_NO, TO_CHAR(CALL_RECV_DT,'dd/mm/yy') CALL_RECV_DT from T17_CALL_REGISTER where CASE_NO not in (select CASE_NO From T20_IC where CASE_NO='"+txtCaseNo.Text.Trim()+"' and CALL_RECV_DT=to_date('"+txtRdt.Text.Trim()+"','dd/mm/yyyy'))";
				//string str1 = "select I.IC_NO, I.CASE_NO, I.BK_NO,I.SET_NO,to_char(I.CALL_RECV_DT,'dd/mm/yyyy')CALL_RECV_DT,C.CALL_SNO,E.IE_SNAME from T20_IC I, T17_CALL_REGISTER C,T09_IE E where I.CASE_NO=C.CASE_NO AND I.CALL_RECV_DT=C.CALL_RECV_DT and I.IE_CD=E.IE_CD"; 
				//string str1 = "select I.IC_NO, C.CASE_NO, I.BK_NO,I.SET_NO,NVL2(I.BILL_NO,'Bill No:'||I.BILL_NO,'Bill Pending') STATUS,to_char(C.CALL_RECV_DT,'dd/mm/yyyy')CALL_RECV_DT,C.CALL_SNO,E.IE_SNAME,trim(N.CONSIGNEE_DESIG)||'/'||trim(N.CONSIGNEE_DEPT)||'/'||trim(N.CONSIGNEE_FIRM||'/'||D.CITY) CONSIGNEE_NAME from T17_CALL_REGISTER C,T20_IC I, T09_IE E,T06_CONSIGNEE N,T03_CITY D where I.CASE_NO(+)=C.CASE_NO AND I.CALL_RECV_DT(+)=C.CALL_RECV_DT AND I.CALL_SNO(+)=C.CALL_SNO AND C.IE_CD=E.IE_CD and I.CONSIGNEE_CD=N.CONSIGNEE_CD and N.CONSIGNEE_CITY=D.CITY_CD"; 
				//string str1 = "select I.IC_NO, C.CASE_NO, I.BK_NO,I.SET_NO,NVL2(I.BILL_NO,'Bill No:'||I.BILL_NO,'Bill Pending') STATUS,to_char(C.CALL_RECV_DT,'dd/mm/yyyy')CALL_RECV_DT,C.CALL_SNO,E.IE_SNAME from T17_CALL_REGISTER C,T20_IC I, T09_IE E where I.CASE_NO(+)=C.CASE_NO AND I.CALL_RECV_DT(+)=C.CALL_RECV_DT AND I.CALL_SNO(+)=C.CALL_SNO AND C.IE_CD=E.IE_CD"; 

				//				string str1 ="Select T20.IC_NO, T18.CASE_NO, T20.BK_NO,T20.SET_NO,NVL2(T20.BILL_NO,'Bill No:'||T20.BILL_NO,'Bill Pending') STATUS, to_char(T18.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT,T18.CALL_SNO,T09.IE_SNAME,"+
				//					"(T06.CONSIGNEE_CD||'-'||nvl2(trim(T06.CONSIGNEE_DESIG),trim(T06.CONSIGNEE_DESIG)||'/','')||nvl2(trim(T06.CONSIGNEE_DEPT),trim(T06.CONSIGNEE_DEPT)||'/','')||nvl2(trim(T06.CONSIGNEE_FIRM),trim(T06.CONSIGNEE_FIRM)||'/','')||NVL2(trim(T06.CONSIGNEE_ADD1),trim(T06.CONSIGNEE_ADD1)||'/','')||NVL2(trim(T03.LOCATION),trim(T03.LOCATION)||' : '||trim(T03.CITY),trim(T03.CITY))) CONSIGNEE "+      
				//					"From T18_CALL_DETAILS T18,T20_IC T20, T09_IE T09,T17_CALL_REGISTER T17,T06_CONSIGNEE T06, T03_CITY T03 "+
				//					"Where T20.CASE_NO(+)=T18.CASE_NO AND T20.CALL_RECV_DT(+)=T18.CALL_RECV_DT AND T20.CONSIGNEE_CD(+)=T18.CONSIGNEE_CD AND "+
				//					"T17.CASE_NO=T18.CASE_NO AND T17.CALL_RECV_DT=T18.CALL_RECV_DT AND T17.CALL_SNO=T18.CALL_SNO AND "+
				//					"T20.CALL_SNO(+)=T18.CALL_SNO AND T17.IE_CD=T09.IE_CD and T06.CONSIGNEE_CD=T18.CONSIGNEE_CD and T06.CONSIGNEE_CITY=T03.CITY_CD and T17.REGION_CODE='"+Session["Region"].ToString()+"'";


				string str1 = "Select IC_NO, CASE_NO, BK_NO,SET_NO,STATUS,to_char(CALL_RECV_DATE,'dd/mm/yyyy') CALL_RECV_DT,CALL_SNO,IE_SNAME,CONSIGNEE, CALL_STATUS_DESC from(";
				str1 = str1 + "Select T20.IC_NO IC_NO, T18.CASE_NO CASE_NO, T20.BK_NO BK_NO,T20.SET_NO SET_NO,NVL2(T20.BILL_NO,'Bill No:'||T20.BILL_NO,'Bill Pending') STATUS, T18.CALL_RECV_DT CALL_RECV_DATE,T18.CALL_SNO CALL_SNO,T09.IE_SNAME IE_SNAME," +
					"(T06.CONSIGNEE_CD||'-'||nvl2(trim(T06.CONSIGNEE_DESIG),trim(T06.CONSIGNEE_DESIG)||'/','')||nvl2(trim(T06.CONSIGNEE_DEPT),trim(T06.CONSIGNEE_DEPT)||'/','')||nvl2(trim(T06.CONSIGNEE_FIRM),trim(T06.CONSIGNEE_FIRM)||'/','')||NVL2(trim(T06.CONSIGNEE_ADD1),trim(T06.CONSIGNEE_ADD1)||'/','')||NVL2(trim(T03.LOCATION),trim(T03.LOCATION)||' : '||trim(T03.CITY),trim(T03.CITY))) CONSIGNEE, T21.CALL_STATUS_DESC  " +
					"From T18_CALL_DETAILS T18,T20_IC T20, T09_IE T09,T17_CALL_REGISTER T17,T06_CONSIGNEE T06, T03_CITY T03, T21_CALL_STATUS_CODES T21 " +
					"Where T20.CASE_NO(+)=T18.CASE_NO AND T20.CALL_RECV_DT(+)=T18.CALL_RECV_DT AND T20.CONSIGNEE_CD(+)=T18.CONSIGNEE_CD AND " +
					"T17.CASE_NO=T18.CASE_NO AND T17.CALL_RECV_DT=T18.CALL_RECV_DT AND T17.CALL_SNO=T18.CALL_SNO AND " +
					"T20.CALL_SNO(+)=T18.CALL_SNO AND T17.IE_CD=T09.IE_CD and T06.CONSIGNEE_CD=T18.CONSIGNEE_CD and T06.CONSIGNEE_CITY=T03.CITY_CD and T17.CALL_STATUS=T21.CALL_STATUS_CD and T17.REGION_CODE='" + Session["Region"].ToString() + "'";

				if (txtBKNo.Text.Trim() != "")
				{
					str1 = str1 + " and upper(T20.BK_NO)=upper('" + txtBKNo.Text.Trim() + "')";

				}

				if (txtSetNo.Text.Trim() != "")
				{
					str1 = str1 + " and T20.SET_NO='" + txtSetNo.Text.Trim() + "'";
				}
				if (txtCaseNo.Text.Trim() != "")
				{

					str1 = str1 + " and upper(T18.CASE_NO)=upper('" + txtCaseNo.Text.Trim() + "')";
				}

				if (txtRdt.Text.Trim() != "")
				{
					str1 = str1 + " and T18.CALL_RECV_DT=to_Date('" + txtRdt.Text.Trim() + "','dd/mm/yyyy')";
				}

				str1 = str1 + " and T17.REGION_CODE='" + Session["Region"].ToString() + "' and T17.CALL_STATUS <> 'C' Group By T18.CASE_NO,T18.CALL_RECV_DT,T18.CALL_SNO,T20.IC_NO,T20.BK_NO,T20.SET_NO,NVL2(T20.BILL_NO,'Bill No:'||T20.BILL_NO,'Bill Pending'), T09.IE_SNAME," +
								"(T06.CONSIGNEE_CD||'-'||nvl2(trim(T06.CONSIGNEE_DESIG),trim(T06.CONSIGNEE_DESIG)||'/','')||nvl2(trim(T06.CONSIGNEE_DEPT),trim(T06.CONSIGNEE_DEPT)||'/','')||nvl2(trim(T06.CONSIGNEE_FIRM),trim(T06.CONSIGNEE_FIRM)||'/','')||NVL2(trim(T06.CONSIGNEE_ADD1),trim(T06.CONSIGNEE_ADD1)||'/','')||NVL2(trim(T03.LOCATION),trim(T03.LOCATION)||' : '||trim(T03.CITY),trim(T03.CITY))),T21.CALL_STATUS_DESC";
				str1 = str1 + ") order by CALL_RECV_DATE,CASE_NO,BK_NO,SET_NO";

				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					btnChangeCon.Visible = false;
					grdIC.Visible = false;
					DisplayAlert("No Bill Pending!!!");
					//Label4.Visible=true;
				}
				else
				{
					grdIC.Visible = true;
					grdIC.DataSource = dsP;
					grdIC.DataBind();
					Label8.Visible = true;
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

		protected void btnChangeCon_Click(object sender, System.EventArgs e)
		{
			string check = match1();
			if (check == "2")
			{
				string bkno = txtBKNo.Text.Trim();
				string sno = txtSetNo.Text.Trim();
				Response.Redirect("ChangeT20_Consignee.aspx?Action=M&BK_NO=" + bkno + "&SET_NO=" + sno);
			}
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			string check = match1();
			if (check == "2")
			{
				string bkno = txtBKNo.Text.Trim();
				string sno = txtSetNo.Text.Trim();
				Response.Redirect("Returned_Bills_BPO_Change_Form.aspx?Action=M&BK_NO=" + bkno + "&SET_NO=" + sno);
			}
		}





	}
}
