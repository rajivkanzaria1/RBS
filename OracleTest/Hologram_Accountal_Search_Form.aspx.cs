using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Hologram_Accountal_Search_Form
{
	public partial class Hologram_Accountal_Search_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		DataSet dsP = new DataSet();
		string BNO, SNO;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnAdd.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelete.Attributes.Add("OnClick", "JavaScript:validate();");
			btnSearch.Attributes.Add("OnClick", "JavaScript:validate2();");

			if (!(IsPostBack))
			{
				if (Convert.ToString(Request.Params["BK_NO"]) == "" && Convert.ToString(Request.Params["SET_NO"]) == "")
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
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{

				//				string str1 ="Select CASE_NO, BK_NO,SET_NO,STATUS,to_char(CALL_RECV_DATE,'dd/mm/yyyy') CALL_RECV_DT,CALL_SNO,IE_SNAME from(";
				//				str1 = str1+ "Select T18.CASE_NO CASE_NO, T20.BK_NO BK_NO,T20.SET_NO SET_NO,NVL2(T20.BILL_NO,'Bill No:'||T20.BILL_NO,'Bill Pending') STATUS, T18.CALL_RECV_DT CALL_RECV_DATE,T18.CALL_SNO CALL_SNO,T09.IE_SNAME IE_SNAME "+
				//					 "From T18_CALL_DETAILS T18,T20_IC T20, T09_IE T09,T17_CALL_REGISTER T17 "+
				//					"Where T20.CASE_NO(+)=T18.CASE_NO AND T20.CALL_RECV_DT(+)=T18.CALL_RECV_DT AND T20.CONSIGNEE_CD(+)=T18.CONSIGNEE_CD AND "+
				//					"T17.CASE_NO=T18.CASE_NO AND T17.CALL_RECV_DT=T18.CALL_RECV_DT AND T17.CALL_SNO=T18.CALL_SNO AND "+
				//					"T20.CALL_SNO(+)=T18.CALL_SNO AND T17.IE_CD=T09.IE_CD and T17.REGION_CODE='"+Session["Region"].ToString()+"'";
				string str1 = "select T20.CASE_NO,T20.BK_NO,T20.SET_NO,NVL2(T33.HG_NO_MATERIAL_FR,T33.HG_REGION||T33.HG_NO_MATERIAL_FR||'-'||T33.HG_REGION||T33.HG_NO_MATERIAL_TO,'-') HG_NO_MATERIAL,NVL2(T33.HG_NO_SAMPLE_FR,T33.HG_REGION||T33.HG_NO_SAMPLE_FR||'-'||T33.HG_REGION||T33.HG_NO_SAMPLE_TO,'-') HG_NO_SAMPLE,NVL2(T33.HG_NO_TEST_FR,T33.HG_REGION||T33.HG_NO_TEST_FR||'-'||T33.HG_REGION||T33.HG_NO_TEST_TO,'-') HG_NO_TEST,NVL2(T33.HG_NO_IC_FR,T33.HG_REGION||T33.HG_NO_IC_FR||'-'||T33.HG_REGION||T33.HG_NO_IC_TO,'-') HG_NO_IC,NVL2(T33.HG_NO_IC_DOC,T33.HG_REGION||T33.HG_NO_IC_DOC,'-') HG_NO_IC_DOC,NVL2(T33.HG_NO_OT_FR,T33.HG_REGION||T33.HG_NO_OT_FR||'-'||T33.HG_REGION||T33.HG_NO_OT_TO||NVL2(T33.HG_OT_DESC,'('||T33.HG_OT_DESC||')',''),'-') HG_NO_OT, T09.IE_SNAME " +
							"from T20_IC T20, T33_HOLOGRAM_ACCOUNTAL T33, T09_IE T09 where T20.CASE_NO=T33.CASE_NO(+) AND T20.CALL_RECV_DT=T33.CALL_RECV_DT(+) AND T20.CONSIGNEE_CD=T33.CONSIGNEE_CD(+) AND T20.CALL_SNO=T33.CALL_SNO(+) and T20.IE_CD=T09.IE_CD and substr(T20.CASE_NO,1,1)='" + Session["Region"].ToString() + "'";
				if (txtBKNo.Text.Trim() != "")
				{
					str1 = str1 + " and upper(T20.BK_NO)=upper('" + txtBKNo.Text.Trim() + "')";
				}
				if (txtSetNo.Text.Trim() != "")
				{
					str1 = str1 + " and T20.SET_NO='" + txtSetNo.Text.Trim() + "'";
				}

				str1 = str1 + " order by BK_NO,SET_NO,CASE_NO";

				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdIC.Visible = false;
					DisplayAlert("IC Not Registered!!!");
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
				conn1.Dispose();
			}
		}

		private void btnMod_Click(object sender, System.EventArgs e)
		{
			string check = match1();
			if (check == "2")
			{
				string bkno = txtBKNo.Text.Trim();
				string sno = txtSetNo.Text.Trim();
				Response.Redirect("Hologram_Accountal_Form.aspx?BK_NO=" + bkno + "&SET_NO=" + sno);
			}
		}
		public string match1()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			OracleCommand cmd = new OracleCommand("select substr(CASE_NO,1,1)REGION_CODE from T20_IC where BK_NO='" + txtBKNo.Text.Trim() + "' and SET_NO='" + txtSetNo.Text.Trim() + "' and substr(CASE_NO,1,1)='" + Session["Region"] + "'", conn1);
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
				DisplayAlert("You are not Authorised to Update/Delete Hologram Data For Other Regions.!!! ");
			}
			return test;
		}

		public string match()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			OracleCommand cmd = new OracleCommand("select substr(CASE_NO,1,1) from T20_IC where BK_NO='" + txtBKNo.Text.Trim() + "' and SET_NO='" + txtSetNo.Text.Trim() + "' and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "'", conn1);
			string test = "";
			conn1.Open();
			test = Convert.ToString(cmd.ExecuteScalar());
			conn1.Close();
			conn1.Dispose();
			if (test == "\0" || test == "")
			{
				test = "0";
				DisplayAlert("No Record Present for the Given Book No and Set No. in IC Master!!!");
			}
			else if (test == Session["Region"].ToString())
			{
				test = "2";

			}
			else
			{
				test = "1";
				DisplayAlert("You are not Authorised to Add Hologram Data For Other Regions.!!! ");
			}

			return test;

		}

		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			string check = match1();
			if (check == "2")
			{
				string bkno = txtBKNo.Text.Trim();
				string sno = txtSetNo.Text.Trim();
				Response.Redirect("Hologram_Accountal_Form.aspx?BK_NO=" + bkno + "&SET_NO=" + sno);
			}
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			string check = match();
			if (check == "2")
			{
				string bkno = txtBKNo.Text.Trim();
				string sno = txtSetNo.Text.Trim();
				Response.Redirect("Hologram_Accountal_Form.aspx?BK_NO=" + bkno + "&SET_NO=" + sno);
			}
		}
	}
}