using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.ChangeT20_Consignee
{
	public partial class ChangeT20_Consignee : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		string BKNO, SNO;

		void fill_ic_details()
		{
			try
			{
				string str3 = "select I.CASE_NO,(I.CONSIGNEE_CD||'-'||nvl2(trim(C.CONSIGNEE_DESIG),trim(C.CONSIGNEE_DESIG)||'/','')||nvl2(trim(C.CONSIGNEE_DEPT),trim(C.CONSIGNEE_DEPT)||'/','')||nvl2(trim(C.CONSIGNEE_FIRM),trim(C.CONSIGNEE_FIRM)||'/','')||NVL2(trim(C.CONSIGNEE_ADD1),trim(C.CONSIGNEE_ADD1)||'/','')||NVL2(trim(D.LOCATION),trim(D.LOCATION)||' : '||trim(D.CITY),trim(D.CITY))) CONSIGNEE_NAME,(NVL2(I.BPO_CD,I.BPO_CD||'-'||(B.BPO_NAME||'/'||B.BPO_RLY||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(E.LOCATION,E.CITY||'/'||E.LOCATION,E.CITY)),'')) BPO_NAME,I.BK_NO,I.SET_NO from T20_IC I,T06_CONSIGNEE C, T12_BILL_PAYING_OFFICER B,T03_CITY D ,T03_CITY E where I.CONSIGNEE_CD=C.CONSIGNEE_CD AND I.BPO_CD=B.BPO_CD AND C.CONSIGNEE_CITY=D.CITY_CD AND B.BPO_CITY_CD=E.CITY_CD and I.BK_NO= '" + BKNO + "' and I.SET_NO='" + SNO + "' and substr(I.CASE_NO,1,1)='" + Session["Region"] + "'";
				OracleCommand myOracleCommand3 = new OracleCommand(str3, conn1);
				conn1.Open();
				OracleDataReader reader = myOracleCommand3.ExecuteReader();
				if (reader.HasRows == false)
				{
					throw new System.Exception("Record not found for the given Book No. and Set No. !!! ");
				}
				else
				{
					while (reader.Read())
					{
						lblCaseNo.Text = reader["CASE_NO"].ToString();
						lblBPO.Text = reader["BPO_NAME"].ToString();
						lblConsignee.Text = reader["CONSIGNEE_NAME"].ToString();
						lblBKNO.Text = reader["BK_NO"].ToString();
						lblSetNo.Text = reader["SET_NO"].ToString();
					}
					reader.Close();
					conn1.Close();
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


		public void fill_ConsigneeCd_PO()
		{
			try
			{
				lstConsignee.Items.Clear();
				DataSet dsP = new DataSet();
				string str1;
				//str1 = "select P.CONSIGNEE_CD,(trim(C.CONSIGNEE_DESIG)||'/'||trim(C.CONSIGNEE_DEPT)||'/'||trim(C.CONSIGNEE_FIRM)) CONSIGNEE_NAME from T06_CONSIGNEE C,T18_CALL_DETAILS P WHERE P.CONSIGNEE_CD=C.CONSIGNEE_CD and CASE_NO='"+ txtCaseNo.Text +"' and CALL_RECV_DT=TO_DATE('"+txtDtOfReciept.Text+"','dd/mm/yyyy')ORDER BY CONSIGNEE_DESIG"; 
				str1 = "Select P.CONSIGNEE_CD,(C.CONSIGNEE_CD||'-'||nvl2(trim(C.CONSIGNEE_DESIG),trim(C.CONSIGNEE_DESIG)||'/','')||nvl2(trim(C.CONSIGNEE_DEPT),trim(C.CONSIGNEE_DEPT)||'/','')||nvl2(trim(C.CONSIGNEE_FIRM),trim(C.CONSIGNEE_FIRM)||'/','')||NVL2(trim(C.CONSIGNEE_ADD1),trim(C.CONSIGNEE_ADD1)||'/','')||NVL2(trim(D.LOCATION),trim(D.LOCATION)||' : '||trim(D.CITY),trim(D.CITY))) CONSIGNEE_NAME from T14_PO_BPO P,t06_consignee C,T03_CITY D where P.CONSIGNEE_CD=C.CONSIGNEE_CD and C.CONSIGNEE_CITY=D.CITY_CD AND P.CASE_NO='" + lblCaseNo.Text + "'";
				//str1="Select C.CONSIGNEE_CD,trim(C.CONSIGNEE_DESIG)||'/'||trim(C.CONSIGNEE_DEPT)||'/'||trim(C.CONSIGNEE_FIRM||'/'||D.CITY) CONSIGNEE_NAME from t06_consignee C,T03_CITY D where C.CONSIGNEE_CITY=D.CITY_CD AND CONSIGNEE_CD in (select distinct CONSIGNEE_CD from T18_CALL_DETAILS WHERE CASE_NO='"+ txtCaseNo.Text +"')";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				ListItem lst;
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					throw new Exception("Their is no details Present for this Case No and Call Recieve Date in CALL DETAILS TABLE !!!");
				}
				else
				{
					for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
					{
						lst = new ListItem();
						lst.Text = dsP.Tables[0].Rows[i]["CONSIGNEE_NAME"].ToString();
						lst.Value = dsP.Tables[0].Rows[i]["CONSIGNEE_CD"].ToString();
						lstConsignee.Items.Add(lst);
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
		}

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:conformation();");
			if (Convert.ToString(Request.Params["BK_NO"]) != "")
			{

				BKNO = Request.Params["BK_NO"].ToString();
				SNO = Request.Params["SET_NO"].ToString();

			}
			if (!(IsPostBack))
			{
				fill_ic_details();
				fill_ConsigneeCd_PO();
				conn1.Open();
				OracleCommand cmd2 = new OracleCommand("Select SENT_TO_SAP FROM T20_IC T20, T22_BILL T22 WHERE T20.BILL_NO=T22.BILL_NO AND T20.BK_NO= '" + BKNO + "' and T20.SET_NO='" + SNO + "' and substr(T20.CASE_NO,1,1)='" + Session["Region"] + "'", conn1);
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				if (ss == "X")
				{
					btnSave.Enabled = false;
				}
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
			conn1.Open();
			try
			{

				OracleCommand cmd1 = new OracleCommand("update T20_IC set CONSIGNEE_CD=" + lstConsignee.SelectedValue + " where BK_NO= '" + BKNO + "' and SET_NO='" + SNO + "' and substr(CASE_NO,1,1)='" + Session["Region"] + "'", conn1);
				cmd1.ExecuteNonQuery();
				conn1.Close();
				fill_ic_details();

			}
			catch (OracleException ex)
			{
				string str = ex.ErrorCode.ToString();
				string str1 = "";
				if (str == "1")
				{
					str1 = "The IC For the Given Case No, Call Date, Call SNo. and Consignee CD Already Present.So You Cannot update the Consignee!!!";
				}
				else
				{
					str1 = str.Replace("\n", "");
				}
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}

			finally
			{
				conn1.Close();
			}
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Inspection_Certificate_Edit_Form.aspx");
		}
	}
}