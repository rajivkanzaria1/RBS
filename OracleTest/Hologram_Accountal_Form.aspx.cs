using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Hologram_Accountal_Form
{
	public partial class Hologram_Accountal_Form : System.Web.UI.Page
	{
		string BNO, SNO;
		int CCD, RNO;
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			if (Convert.ToString(Request.Params["BK_NO"]) == "" && Convert.ToString(Request.Params["SET_NO"]) == "" && Convert.ToString(Request.Params["CASE_NO"]) == "")
			{
				BNO = "";
				SNO = "";
				RNO = 0;
			}
			else if (Convert.ToString(Request.Params["BK_NO"]) != "" && Convert.ToString(Request.Params["SET_NO"]) != null)
			{
				BNO = Convert.ToString(Request.Params["BK_NO"]);
				SNO = Convert.ToString(Request.Params["SET_NO"]);
				RNO = 0;
			}
			else if (Convert.ToString(Request.Params["CASE_NO"]) != "")
			{
				txtCaseNo.Text = Convert.ToString(Request.Params["CASE_NO"]);
				txtDtOfReciept.Text = Convert.ToString(Request.Params["CALL_RECV_DT"]);
				lblCSNO.Text = Convert.ToString(Request.Params["CALL_SNO"]);
				CCD = Convert.ToInt32(Request.Params["CONSIGNEE_CD"]);
				RNO = 0;
				if (Convert.ToString(Request.Params["REC_NO"]) != "")
				{
					RNO = Convert.ToInt32(Request.Params["REC_NO"]);
				}
			}
			if (!(IsPostBack))
			{
				if (Convert.ToString(Request.Params["BK_NO"]) == "" && Convert.ToString(Request.Params["SET_NO"]) == "" && Convert.ToString(Request.Params["CASE_NO"]) == "")
				{
					BNO = "";
					SNO = "";
				}
				else if (Convert.ToString(Request.Params["BK_NO"]) != "" && Convert.ToString(Request.Params["SET_NO"]) != null)
				{
					show();
				}
				else if (Convert.ToString(Request.Params["CASE_NO"]) != "")
				{

					show();
					btnDel.Visible = false;
					if (Convert.ToString(Request.Params["REC_NO"]) != "")
					{
						show2();
						btnDel.Visible = true;
					}
				}
				fillgrid();
				lblReg1.Text = Session["Region"].ToString();
				lblReg2.Text = Session["Region"].ToString();
				lblReg3.Text = Session["Region"].ToString();
				lblReg4.Text = Session["Region"].ToString();
				lblReg5.Text = Session["Region"].ToString();
				lblReg6.Text = Session["Region"].ToString();
				lblReg7.Text = Session["Region"].ToString();
				lblReg8.Text = Session["Region"].ToString();
				lblReg9.Text = Session["Region"].ToString();
				lblReg10.Text = Session["Region"].ToString();
				lblReg11.Text = Session["Region"].ToString();
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
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string str3 = "";
				if (Convert.ToString(Request.Params["BK_NO"]) == "" || Convert.ToString(Request.Params["BK_NO"]) == null)
				{
					str3 = "select T20.CASE_NO, to_char(T20.CALL_RECV_DT,'dd/mm/yyyy')CALL_DT, T20.CALL_SNO,T20.BK_NO,T20.SET_NO,T20.CONSIGNEE_CD, T09.IE_NAME,T20.IE_CD from T20_IC T20, T09_IE T09 where T20.IE_CD=T09.IE_CD and CASE_NO='" + txtCaseNo.Text + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and CONSIGNEE_CD=" + CCD + " and CALL_SNO=" + lblCSNO.Text;
				}
				else if (Convert.ToString(Request.Params["CASE_NO"]) == "" || Convert.ToString(Request.Params["CASE_NO"]) == null)
				{
					str3 = "select T20.CASE_NO, to_char(T20.CALL_RECV_DT,'dd/mm/yyyy')CALL_DT, T20.CALL_SNO,T20.BK_NO,T20.SET_NO,T20.CONSIGNEE_CD, T09.IE_NAME,T20.IE_CD from T20_IC T20, T09_IE T09 where T20.IE_CD=T09.IE_CD and BK_NO='" + BNO + "' and SET_NO='" + SNO + "' and substr(CASE_NO,1,1)='" + Session["Region"] + "' ";
				}
				OracleCommand myOracleCommand3 = new OracleCommand(str3, conn1);
				conn1.Open();
				OracleDataReader reader = myOracleCommand3.ExecuteReader();
				while (reader.Read())
				{
					txtCaseNo.Text = reader["CASE_NO"].ToString();
					txtDtOfReciept.Text = reader["CALL_DT"].ToString();
					lblCSNO.Text = reader["CALL_SNO"].ToString();
					lblIE.Text = reader["IE_NAME"].ToString();
					lblBKNO.Text = reader["BK_NO"].ToString();
					lblSetNO.Text = reader["SET_NO"].ToString();
					CCD = Convert.ToInt32(reader["CONSIGNEE_CD"].ToString());
					lblCCD.Text = Convert.ToString(reader["CONSIGNEE_CD"].ToString());
					lblIECD.Text = Convert.ToString(reader["IE_CD"].ToString());
				}
				reader.Close();
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

		void show2()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string str3 = "SELECT REC_NO,HG_NO_MATERIAL_FR,HG_NO_MATERIAL_TO,HG_NO_SAMPLE_FR,HG_NO_SAMPLE_TO,HG_NO_TEST_FR,HG_NO_TEST_TO,HG_NO_IC_FR,HG_NO_IC_TO,HG_NO_IC_DOC,HG_OT_DESC,HG_NO_OT_FR,HG_NO_OT_TO from T33_HOLOGRAM_ACCOUNTAL where CASE_NO='" + txtCaseNo.Text + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and CONSIGNEE_CD=" + CCD + " and CALL_SNO=" + lblCSNO.Text + " and REC_NO=" + RNO;
				OracleCommand myOracleCommand3 = new OracleCommand(str3, conn1);
				conn1.Open();
				OracleDataReader reader = myOracleCommand3.ExecuteReader();
				while (reader.Read())
				{
					txtHGNOMatFR.Text = reader["HG_NO_MATERIAL_FR"].ToString();
					txtHGNOMatTO.Text = reader["HG_NO_MATERIAL_TO"].ToString();
					txtHGNOSampFR.Text = reader["HG_NO_SAMPLE_FR"].ToString();
					txtHGNOSampTO.Text = reader["HG_NO_SAMPLE_TO"].ToString();
					txtHGNOTestFR.Text = reader["HG_NO_TEST_FR"].ToString();
					txtHGNOTestTo.Text = reader["HG_NO_TEST_TO"].ToString();
					txtHGNOICFR.Text = reader["HG_NO_IC_FR"].ToString();
					txtHGNOICTO.Text = reader["HG_NO_IC_TO"].ToString();
					txtHGNOICDoc.Text = reader["HG_NO_IC_DOC"].ToString();
					txtHGNOOTFR.Text = reader["HG_NO_OT_FR"].ToString();
					txtHGNOOTTO.Text = reader["HG_NO_OT_TO"].ToString();
					txtOTDESC.Text = reader["HG_OT_DESC"].ToString();
				}
				reader.Close();
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
		void fillgrid()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "SELECT CASE_NO,CONSIGNEE_CD,to_char(CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT,CALL_SNO,REC_NO,NVL2(HG_NO_MATERIAL_FR,HG_REGION||HG_NO_MATERIAL_FR||'-'||HG_REGION||HG_NO_MATERIAL_TO,'-') HG_NO_MATERIAL,NVL2(HG_NO_SAMPLE_FR,HG_REGION||HG_NO_SAMPLE_FR||'-'||HG_REGION||HG_NO_SAMPLE_TO,'-') HG_NO_SAMPLE,NVL2(HG_NO_TEST_FR,HG_REGION||HG_NO_TEST_FR||'-'||HG_REGION||HG_NO_TEST_TO,'-') HG_NO_TEST,NVL2(HG_NO_IC_FR,HG_REGION||HG_NO_IC_FR||'-'||HG_REGION||HG_NO_IC_TO,'-') HG_NO_IC,NVL2(HG_NO_IC_DOC,HG_REGION||HG_NO_IC_DOC,'-') HG_NO_IC_DOC,NVL2(HG_NO_OT_FR,HG_REGION||HG_NO_OT_FR||'-'||HG_REGION||HG_NO_OT_TO||NVL2(HG_OT_DESC,'('||HG_OT_DESC||')',''),'-') HG_NO_OT from T33_HOLOGRAM_ACCOUNTAL where CASE_NO='" + txtCaseNo.Text + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and CONSIGNEE_CD=" + lblCCD.Text + " and CALL_SNO=" + lblCSNO.Text + " Order by REC_NO";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				grdHG.Caption = "<span class=MyDataGridCaption>HOLOGRAM USED ON</span>";
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdHG.Visible = false;
				}
				else
				{
					grdHG.Visible = true;
					grdHG.DataSource = dsP;
					grdHG.DataBind();

				}
				conn1.Close();
				conn1.Dispose();
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

		int getrecno()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			string str1 = "select nvl(max(REC_NO),0)+1  from T33_HOLOGRAM_ACCOUNTAL where CASE_NO='" + txtCaseNo.Text + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and CONSIGNEE_CD=" + lblCCD.Text + " and CALL_SNO=" + lblCSNO.Text;
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			conn1.Open();
			int isrno = Convert.ToInt32(myOracleCommand.ExecuteScalar());
			conn1.Close();
			conn1.Dispose();
			return (isrno);
		}

		void clear()
		{
			txtHGNOMatFR.Text = "";
			txtHGNOMatTO.Text = "";
			txtHGNOSampFR.Text = "";
			txtHGNOSampTO.Text = "";
			txtHGNOTestFR.Text = "";
			txtHGNOTestTo.Text = "";
			txtHGNOICFR.Text = "";
			txtHGNOICTO.Text = "";
			txtHGNOICDoc.Text = "";
			txtHGNOOTFR.Text = "";
			txtHGNOOTTO.Text = "";
			txtOTDESC.Text = "";
		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			string message = check_duplicate_holograms();
			if (message == "0")
			{
				if (RNO == 0)
				{
					int rec_no = getrecno();
					conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
					conn1.Open();
					OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
					string ss = Convert.ToString(cmd2.ExecuteScalar());
					//conn1.Close();
					try
					{
						OracleCommand cmd1 = new OracleCommand("insert into T33_HOLOGRAM_ACCOUNTAL(CASE_NO,CALL_RECV_DT,CONSIGNEE_CD,CALL_SNO,REC_NO,HG_REGION,HG_NO_MATERIAL_FR,HG_NO_MATERIAL_TO,HG_NO_SAMPLE_FR,HG_NO_SAMPLE_TO,HG_NO_TEST_FR,HG_NO_TEST_TO,HG_NO_IC_FR,HG_NO_IC_TO,HG_NO_IC_DOC,HG_NO_OT_FR,HG_NO_OT_TO,HG_OT_DESC, USER_ID, DATETIME) values('" + txtCaseNo.Text + "',to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy')," + lblCCD.Text + "," + lblCSNO.Text + "," + rec_no + ",'" + Session["Region"] + "','" + txtHGNOMatFR.Text + "','" + txtHGNOMatTO.Text + "','" + txtHGNOSampFR.Text + "','" + txtHGNOSampTO.Text + "','" + txtHGNOTestFR.Text + "','" + txtHGNOTestTo.Text + "','" + txtHGNOICFR.Text + "','" + txtHGNOICTO.Text + "','" + txtHGNOICDoc.Text + "','" + txtHGNOOTFR.Text + "','" + txtHGNOOTTO.Text + "','" + txtOTDESC.Text + "','" + Session["Uname"] + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))", conn1);
						cmd1.ExecuteNonQuery();
						conn1.Close();
						fillgrid();
						clear();
						btnSave.Visible = true;
						btnDel.Visible = false;

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
				else if (RNO > 0)
				{

					conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
					conn1.Open();
					OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
					string ss = Convert.ToString(cmd2.ExecuteScalar());
					//conn1.Close();
					try
					{
						OracleCommand cmd1 = new OracleCommand("update T33_HOLOGRAM_ACCOUNTAL set HG_NO_MATERIAL_FR='" + txtHGNOMatFR.Text + "',HG_NO_MATERIAL_TO='" + txtHGNOMatTO.Text + "',HG_NO_SAMPLE_FR='" + txtHGNOSampFR.Text + "',HG_NO_SAMPLE_TO='" + txtHGNOSampTO.Text + "',HG_NO_TEST_FR='" + txtHGNOTestFR.Text + "',HG_NO_TEST_TO='" + txtHGNOTestTo.Text + "',HG_NO_IC_FR='" + txtHGNOICFR.Text + "',HG_NO_IC_TO='" + txtHGNOICTO.Text + "',HG_NO_IC_DOC='" + txtHGNOICDoc.Text + "',HG_NO_OT_FR='" + txtHGNOOTFR.Text + "',HG_NO_OT_TO='" + txtHGNOOTTO.Text + "',HG_OT_DESC='" + txtOTDESC.Text + "', USER_ID='" + Session["Uname"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where CASE_NO='" + txtCaseNo.Text + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and CONSIGNEE_CD=" + lblCCD.Text + " and CALL_SNO=" + lblCSNO.Text + " and REC_NO=" + RNO, conn1);
						cmd1.ExecuteNonQuery();
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
					Response.Redirect("Hologram_Accountal_Form.aspx?CASE_NO=" + txtCaseNo.Text + "&CALL_RECV_DT=" + txtDtOfReciept.Text + "&CALL_SNO=" + lblCSNO.Text + "&CONSIGNEE_CD=" + CCD);
				}
			}
			else
			{
				Response.Write("<script language=JavaScript> alert('" + message + "'); </script>");
			}
		}

		protected void btnDel_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			try
			{
				OracleCommand cmd1 = new OracleCommand("delete from T33_HOLOGRAM_ACCOUNTAL where CASE_NO='" + txtCaseNo.Text + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and CONSIGNEE_CD=" + lblCCD.Text + " and CALL_SNO=" + lblCSNO.Text + " and REC_NO=" + RNO, conn1);
				cmd1.ExecuteNonQuery();
				conn1.Close();
				clear();
				fillgrid();
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

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Hologram_Accountal_Search_Form.aspx");
		}

		string check_duplicate_holograms()
		{
			string msg = "";
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			string str1 = "Select sum(a)a,sum(b)b,sum(c)c,sum(d)d,sum(e)e,sum(f)f from(" +
						 "Select count(*) a,0 b,0 c,0 d,0 e,0 f from T31_HOLOGRAM_ISSUED where HG_NO_FR<='" + txtHGNOMatFR.Text + "' and HG_NO_TO >='" + txtHGNOMatTO.Text + "' and HG_IECD=" + lblIECD.Text + " and HG_REGION='" + Session["Region"] + "' union all " +
						 "Select 0 a,count(*) b,0 c,0 d,0 e,0 f from T31_HOLOGRAM_ISSUED where HG_NO_FR<='" + txtHGNOSampFR.Text + "' and HG_NO_TO >='" + txtHGNOSampTO.Text + "' and HG_IECD=" + lblIECD.Text + " and HG_REGION='" + Session["Region"] + "' union all " +
						 "Select 0 a,0 b,count(*) c,0 d,0 e,0 f from T31_HOLOGRAM_ISSUED where HG_NO_FR<='" + txtHGNOTestFR.Text + "' and HG_NO_TO >='" + txtHGNOTestTo.Text + "' and HG_IECD=" + lblIECD.Text + " and HG_REGION='" + Session["Region"] + "' union all " +
						 "Select 0 a,0 b,0 c,count(*) d,0 e,0 f from T31_HOLOGRAM_ISSUED where HG_NO_FR<='" + txtHGNOICFR.Text + "' and HG_NO_TO >='" + txtHGNOICTO.Text + "' and HG_IECD=" + lblIECD.Text + " and HG_REGION='" + Session["Region"] + "' union all " +
						 "Select 0 a,0 b,0 c,0 d,count(*) e,0 f from T31_HOLOGRAM_ISSUED where HG_NO_FR<='" + txtHGNOICDoc.Text + "' and HG_NO_TO >='" + txtHGNOICDoc.Text + "' and HG_IECD=" + lblIECD.Text + " and HG_REGION='" + Session["Region"] + "' union all " +
						 "Select 0 a,0 b,0 c,0 d,0 e,count(*) f from T31_HOLOGRAM_ISSUED where HG_NO_FR<='" + txtHGNOOTFR.Text + "' and HG_NO_TO >='" + txtHGNOOTTO.Text + "' and HG_IECD=" + lblIECD.Text + " and HG_REGION='" + Session["Region"] + "')";
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			conn1.Open();
			OracleDataReader reader = myOracleCommand.ExecuteReader();
			while (reader.Read())
			{
				if (Convert.ToInt16(reader["a"]) == 0 & txtHGNOMatFR.Text.Trim() != "") { msg = msg + "- Material/Stores"; }
				if (Convert.ToInt16(reader["b"]) == 0 & txtHGNOSampFR.Text.Trim() != "") { msg = msg + "- Samples"; }
				if (Convert.ToInt16(reader["c"]) == 0 & txtHGNOTestFR.Text.Trim() != "") { msg = msg + "- Test Request Slip"; }
				if (Convert.ToInt16(reader["d"]) == 0 & txtHGNOICFR.Text.Trim() != "") { msg = msg + "- IC"; }
				if (Convert.ToInt16(reader["e"]) == 0 & txtHGNOICDoc.Text.Trim() != "") { msg = msg + "- IC Documents"; }
				if (Convert.ToInt16(reader["f"]) == 0 & txtHGNOOTFR.Text.Trim() != "") { msg = msg + "- Other Locations"; }
				if (msg.Trim() == "") { return ("0"); }
				else { return ("Hologram Numbers entered for " + msg + " - are not issued to the IE!!!"); }
			}
			reader.Close();
			conn1.Close();
			conn1.Dispose();
			return (msg);
		}
	}
}