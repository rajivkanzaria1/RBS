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

namespace RBS.MA_APPROVE_FORM
{
	public partial class MA_APPROVE_FORM : System.Web.UI.Page
	{
		string case_no_ap, ma_no, ma_dtc, ma_sno, ma_dt_change;
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			AP_BT.Attributes.Add("OnClick", "JavaScript:validate1();");
			if (!IsPostBack)
			{
				ListItem lst = new ListItem();
				lst.Text = "";
				lst.Value = "";
				lstClientType.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "Railways";
				lst.Value = "R";
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
			}
			if (Convert.ToString(Request.QueryString["CASE_NO"]) == null || Convert.ToString(Request.QueryString["CASE_NO"]) == "" || Convert.ToString(Request.QueryString["MA_NO"]) == null || Convert.ToString(Request.QueryString["MA_DTC"]) == null || Convert.ToString(Request.QueryString["MA_SNO"]) == null)
			{
				//DisplayAlert("ENTERED CASE NUMBER NOT Found!!!");
				case_no_ap = "";
				ma_no = "";
				ma_dtc = "";
				ma_sno = "";

			}
			else
			{
				case_no_ap = Request.QueryString["CASE_NO"].ToString();
				lblCasNo.Text = case_no_ap;
				ma_no = Request.QueryString["MA_NO"].ToString();
				txtMAN.Text = ma_no;
				txtMAN.Enabled = false;
				ma_dtc = Request.QueryString["MA_DTC"].ToString();
				ma_dt_change = dateconcate1(ma_dtc);
				txtMAdate.Text = ma_dt_change;
				txtMAdate.Enabled = false;
				ma_sno = Request.QueryString["MA_SNO"].ToString();
				Label_Sno.Text = ma_sno;
				Label_Sno.Enabled = false;
				//AP_BT.Visible=true;
				show();
				Show_File();
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
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				DataSet dsP = new DataSet();
				string str2 = "select m.CASE_NO CASE_NO,m.PO_NO PO_NO,to_char(m.PO_DT,'dd/mm/yyyy')PO_DT,m.MA_NO MA_NO,to_char(m.MA_DT,'dd/mm/yyyy')MA_DT,m.RLY_NONRLY RLY_NONRLY,(decode(m.RLY_NONRLY,'R','Railway','P','Private','S','State Government','F','Foreign Railways','U','PSU')||'('||m.RLY_CD||')')RLY_CD,m.PO_OR_LETTER PO_OR_LETTER,d.MA_SNO MA_SNO,d.MA_FIELD MA_FIELD,(decode(d.MA_STATUS,'P','Pending','A','Approved','R','Return')) MA_STATUS,d.MA_REMARKS MA_REMARKS,d.MA_DESC MA_DESC,d.OLD_PO_VALUE OLD_PO_VALUE,d.NEW_PO_VALUE NEW_PO_VALUE from VEND_PO_MA_MASTER m,VEND_PO_MA_DETAIL d where m.Case_no=d.Case_no and m.ma_no= d.ma_no and m.ma_dt=d.ma_dt and d.ma_status='P' and d.case_no='" + lblCasNo.Text + "' and d.ma_no='" + txtMAN.Text + "' and to_char(d.ma_dt, 'dd/mm/yyyy')='" + txtMAdate.Text + "' and d.ma_sno='" + Label_Sno.Text.Trim() + "'"; ;
				OracleDataAdapter da = new OracleDataAdapter(str2, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str2, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					throw new System.Exception("No Record Found!!! For The Given Code");
				}
				else
				{
					//					lblCasNo.Text = dsP.Tables[0].Rows[0]["CASE_NO"].ToString();
					//					lblCasNo.Enabled=false;
					lblPNo.Text = dsP.Tables[0].Rows[0]["PO_NO"].ToString();
					lblPNo.Enabled = false;
					lblPDt.Text = Convert.ToString(dsP.Tables[0].Rows[0]["PO_DT"]);
					lblPDt.Enabled = false;
					//					txtMAN.Text= Convert.ToString(dsP.Tables[0].Rows[0]["MA_NO"]);
					//					txtMAN.Enabled=false;
					//					txtMAdate.Text= Convert.ToString(dsP.Tables[0].Rows[0]["MA_DT"]);
					//					txtMAdate.Enabled=false;
					lstClientType.SelectedValue = Convert.ToString(dsP.Tables[0].Rows[0]["RLY_NONRLY"]);
					lstClientType.Enabled = false;
					lblR_Code.Text = Convert.ToString(dsP.Tables[0].Rows[0]["RLY_CD"]);
					lblR_Code.Enabled = false;
					DL_PO.SelectedValue = Convert.ToString(dsP.Tables[0].Rows[0]["PO_OR_LETTER"]);
					DL_PO.Enabled = false;
					txtMAD.Text = Convert.ToString(dsP.Tables[0].Rows[0]["MA_DESC"]);
					txtMAD.Enabled = false;
					txtMAOV.Text = Convert.ToString(dsP.Tables[0].Rows[0]["OLD_PO_VALUE"]);
					txtMAOV.Enabled = false;
					txtMANV.Text = Convert.ToString(dsP.Tables[0].Rows[0]["NEW_PO_VALUE"]);
					txtMANV.Enabled = false;
					Txt_MAF.Text = Convert.ToString(dsP.Tables[0].Rows[0]["MA_FIELD"]);
					Txt_MAF.Enabled = false;

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

		protected void AP_BT_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (DL_status.SelectedValue == "")
				{
					DisplayAlert("Status Can not Left Blank!!!");
				}
				else
				{
					conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
					conn1.Open();
					OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
					string ss = Convert.ToString(cmd2.ExecuteScalar());
					conn1.Close();
					//conn1=new System.Data.OracleClient.OracleConnection((ConfigurationSettings.AppSettings["ConnectionString"])) ;
					OracleCommand cmd4 = new OracleCommand("update VEND_PO_MA_DETAIL set MA_STATUS='" + DL_status.SelectedValue + "',APPROVED_BY ='" + Session["Uname"].ToString() + "',APPROVED_DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where  CASE_NO='" + lblCasNo.Text + "' and MA_NO='" + txtMAN.Text + "' and to_char(MA_DT,'dd/mm/yyyy')='" + txtMAdate.Text.Trim() + "' and MA_SNO='" + Label_Sno.Text.Trim() + "'", conn1);
					conn1.Open();
					cmd4.ExecuteNonQuery();
					conn1.Close();
					DisplayAlert("MA Has Been Approved!!!");
					AP_BT.Visible = false;
					btnSave.Visible = false;
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

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (Txt_RE.Text == "")
				{
					DisplayAlert("Remarks Can not Left Blank!!!");
				}
				else if (DL_status.SelectedValue == "")
				{
					DisplayAlert("Status Can not Left Blank!!!");
				}
				else
				{
					conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
					conn1.Open();
					OracleCommand cmd21 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
					string ss1 = Convert.ToString(cmd21.ExecuteScalar());
					conn1.Close();
					//conn1=new System.Data.OracleClient.OracleConnection((ConfigurationSettings.AppSettings["ConnectionString"])) ;
					OracleCommand cmd41 = new OracleCommand("update VEND_PO_MA_DETAIL set MA_STATUS='" + DL_status.SelectedValue + "',MA_REMARKS='" + Txt_RE.Text.Trim() + "',APPROVED_BY ='" + Session["Uname"].ToString() + "',APPROVED_DATETIME=to_date('" + ss1 + "','dd/mm/yyyy-HH24:MI:SS') where  CASE_NO='" + lblCasNo.Text + "' and MA_NO='" + txtMAN.Text + "' and to_char(MA_DT,'dd/mm/yyyy')='" + txtMAdate.Text.Trim() + "' and MA_SNO='" + Label_Sno.Text.Trim() + "'", conn1);
					conn1.Open();
					cmd41.ExecuteNonQuery();
					conn1.Close();
					DisplayAlert("MA Has Been Return!!!");
					AP_BT.Visible = false;
					btnSave.Visible = false;
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

		string dateconcate1(string dt)
		{
			string myYear, myMonth, myDay;

			myDay = dt.Substring(0, 2);
			myMonth = dt.Substring(2, 2);
			myYear = dt.Substring(4, 4);
			string dt2 = myDay + '/' + myMonth + '/' + myYear;
			return (dt2);
		}

		void Show_File()
		{
			string MyFile_ma;
			string mdt_ma = dateconcate(txtMAdate.Text.Trim());
			MyFile_ma = lblCasNo.Text.Trim() + '_' + txtMAN.Text.Trim() + '_' + mdt_ma;

			string fpath = Server.MapPath("/RBS/VENDOR/MA/" + MyFile_ma + ".PDF");
			if (File.Exists(fpath) == false)
			{
				HyperLink1.Visible = false;
			}
			else
			{
				HyperLink1.Visible = true;
				HyperLink1.Text = MyFile_ma;
				HyperLink1.NavigateUrl = "/RBS/VENDOR/MA/" + MyFile_ma + ".PDF";
			}

		}

		string dateconcate(string dt)
		{
			string myYear, myMonth, myDay;

			myYear = dt.Substring(6, 4);
			myMonth = dt.Substring(3, 2);
			myDay = dt.Substring(0, 2);
			string dt1 = myYear + myMonth + myDay;
			return (dt1);
		}

		protected void DL_status_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (DL_status.SelectedValue == "R")
			{
				AP_BT.Visible = false;
				btnSave.Visible = true;
				Label_RE.Visible = true;
				Txt_RE.Visible = true;
			}
			else
			{
				AP_BT.Visible = true;
				btnSave.Visible = false;
				Label_RE.Visible = false;
				Txt_RE.Visible = false;

			}
		}


	}
}