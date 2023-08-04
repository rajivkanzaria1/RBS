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

namespace RBS.CLIENT_MA_FORM
{
	public partial class CLIENT_MA_FORM : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		string case_no, ma_no, ma_dt, ma_stu, Action, ma_dt_change, ma_Sno;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			BtnExist.Attributes.Add("OnClick", "JavaScript:validate1();");


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

				if (Convert.ToString(Request.QueryString["CaseNo"]) == null || Convert.ToString(Request.QueryString["CaseNo"]) == "")
				{
					DisplayAlert("ENTERED CASE NUMBER NOT Found!!!");
				}
				else
				{
					case_no = Request.QueryString["CaseNo"].ToString();
					lblCasNo.Text = case_no;
					//AP_BT.Visible=false;
					Action = Request.QueryString["Action"].ToString();

					if (Action == "N")
					{
						btnSave.Visible = true;
						btnUpdate.Visible = false;
						BtnExist.Visible = false;
						Label_RE.Visible = false;
						Txt_RE.Visible = false;
						Label13.Visible = true;
						File2.Visible = true;
						search();
						fillgrid();
						//Show_File();
					}
					if (Action == "E")
					{
						ma_no = Request.QueryString["MaNo"].ToString();
						txtMAN.Text = ma_no;
						txtMAN.Enabled = false;
						ma_dt = Request.QueryString["MaDt"].ToString();
						ma_dt_change = dateconcate1(ma_dt);
						txtMAdate.Text = ma_dt_change;
						txtMAdate.Enabled = false;
						Label13.Visible = false;
						File2.Visible = false;
						ma_stu = Request.QueryString["MaStu"].ToString();
						ma_Sno = Request.QueryString["MaSno"].ToString();
						if (ma_stu == "Pending")
						{
							search();
							Label_RE.Visible = false;
							Txt_RE.Visible = false;
							btnSave.Visible = false;
							btnUpdate.Visible = false;
							BtnExist.Visible = true;
							fillgrid();
						}
						else
						{
							Label_RE.Visible = true;
							Txt_RE.Visible = true;
							ma_Sno = Request.QueryString["MaSno"].ToString();
							Label_Sno.Text = ma_Sno;
							search_Exs_MA();
							btnSave.Visible = false;
							btnUpdate.Visible = true;
							BtnExist.Visible = false;
							Show_File();
							fillgrid();

						}
						//search_Exs_MA();

					}

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



		public void search()
		{
			try
			{
				DataSet reader = new DataSet();
				string str1 = "select CASE_NO,PO_NO,to_char(PO_DT,'dd/mm/yyyy')PO_DT,RLY_CD,PO_OR_LETTER,RLY_NONRLY from t13_po_master where CASE_NO='" + lblCasNo.Text + "'";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand cmd = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = cmd;
				da.Fill(reader, "Table");
				conn1.Close();

				lblCasNo.Text = Convert.ToString(reader.Tables[0].Rows[0]["CASE_NO"]);
				lblPNo.Text = Convert.ToString(reader.Tables[0].Rows[0]["PO_NO"]);
				lblPDt.Text = Convert.ToString(reader.Tables[0].Rows[0]["PO_DT"]);
				lblR_Code.Text = Convert.ToString(reader.Tables[0].Rows[0]["RLY_CD"]);
				DL_PO.SelectedValue = Convert.ToString(reader.Tables[0].Rows[0]["PO_OR_LETTER"]);
				DL_PO.Enabled = false;
				lstClientType.SelectedValue = Convert.ToString(reader.Tables[0].Rows[0]["RLY_NONRLY"]);
				lstClientType.Enabled = false;

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = "There is no row at position 0.";
				if (str.Equals(str1))
				{
					str1 = "Their is no record present for the given Case No.";
				}
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}
			finally
			{
				conn1.Close();
			}
		}


		public void search_Exs_MA()
		{
			try
			{
				DataSet reader1 = new DataSet();
				string str2 = "select m.CASE_NO CASE_NO,m.PO_NO PO_NO,to_char(m.PO_DT,'dd/mm/yyyy')PO_DT,m.MA_NO MA_NO,to_char(m.MA_DT,'dd/mm/yyyy')MA_DT,m.RLY_NONRLY RLY_NONRLY,(decode(m.RLY_NONRLY,'R','Railway','P','Private','S','State Government','F','Foreign Railways','U','PSU')||'('||m.RLY_CD||')')RLY_CD,m.PO_OR_LETTER PO_OR_LETTER,d.MA_SNO MA_SNO,d.MA_FIELD MA_FIELD,d.MA_STATUS MA_STATUS,d.MA_DESC MA_DESC,d.OLD_PO_VALUE OLD_PO_VALUE,d.NEW_PO_VALUE NEW_PO_VALUE,d.MA_REMARKS MA_REMARKS from VEND_PO_MA_MASTER m,VEND_PO_MA_DETAIL d, T13_PO_MASTER t13 " +
					"where t13.rly_cd='" + Session["ORGN"].ToString() + "' and t13.case_no=m.Case_no and m.Case_no=d.Case_no and m.ma_no=d.ma_no and m.ma_dt=d.ma_dt and d.case_no='" + lblCasNo.Text + "' and d.ma_no='" + txtMAN.Text + "' and to_char(d.ma_dt, 'dd/mm/yyyy')='" + txtMAdate.Text + "' and d.ma_sno='" + Label_Sno.Text.Trim() + "'";
				OracleDataAdapter da1 = new OracleDataAdapter(str2, conn1);
				OracleCommand cmd1 = new OracleCommand(str2, conn1);
				conn1.Open();
				da1.SelectCommand = cmd1;
				da1.Fill(reader1, "Table");
				conn1.Close();

				lblCasNo.Text = Convert.ToString(reader1.Tables[0].Rows[0]["CASE_NO"]);
				lblPNo.Text = Convert.ToString(reader1.Tables[0].Rows[0]["PO_NO"]);
				lblPDt.Text = Convert.ToString(reader1.Tables[0].Rows[0]["PO_DT"]);
				lblR_Code.Text = Convert.ToString(reader1.Tables[0].Rows[0]["RLY_CD"]);
				DL_PO.SelectedValue = Convert.ToString(reader1.Tables[0].Rows[0]["PO_OR_LETTER"]);
				DL_PO.Enabled = false;
				txtMAN.Text = Convert.ToString(reader1.Tables[0].Rows[0]["MA_NO"]);
				txtMAdate.Text = Convert.ToString(reader1.Tables[0].Rows[0]["MA_DT"]);
				lstClientType.SelectedValue = Convert.ToString(reader1.Tables[0].Rows[0]["RLY_NONRLY"]);
				lstClientType.Enabled = false;
				Txt_MAF.Text = Convert.ToString(reader1.Tables[0].Rows[0]["MA_FIELD"]);
				txtMAD.Text = Convert.ToString(reader1.Tables[0].Rows[0]["MA_DESC"]);
				txtMAOV.Text = Convert.ToString(reader1.Tables[0].Rows[0]["OLD_PO_VALUE"]);
				txtMANV.Text = Convert.ToString(reader1.Tables[0].Rows[0]["NEW_PO_VALUE"]);
				Txt_RE.Text = Convert.ToString(reader1.Tables[0].Rows[0]["MA_REMARKS"]);
				Txt_RE.Enabled = false;

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = "There is no row at position 0.";
				if (str.Equals(str1))
				{
					str1 = "Their is no record present for the given Case No.";
				}
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}
			finally
			{
				conn1.Close();
			}
		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				string MAcheckquery = "Select count(*) from VEND_PO_MA_MASTER where CASE_NO='" + lblCasNo.Text.Trim() + "' and MA_NO='" + txtMAN.Text.Trim() + "' and  to_char(MA_DT, 'dd/mm/yyyy')='" + txtMAdate.Text.Trim() + "'";
				OracleCommand ClientcheckCommand = new OracleCommand(MAcheckquery, conn1);
				conn1.Open();
				System.Data.DataSet ds = new DataSet();
				OracleDataAdapter adapter = new OracleDataAdapter(ClientcheckCommand);
				adapter.Fill(ds);
				conn1.Close();
				if (Convert.ToInt64(ds.Tables[0].Rows[0][0]) > 0)
				{
					DisplayAlert("Selected CASE NO,MA NO and MA DATE already Exist!!!");
					return;
				}
				else
				{
					conn1.Open();
					OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
					string ss = Convert.ToString(cmd2.ExecuteScalar());
					OracleTransaction myTrans = conn1.BeginTransaction();

					string Clientquery = "INSERT INTO vend_po_ma_master(CASE_NO,MA_NO,MA_DT,PO_NO,PO_DT,RLY_NONRLY,RLY_CD,PO_OR_LETTER,PO_SRC) " +
						"VALUES('" + lblCasNo.Text.Trim() + "','" + txtMAN.Text.Trim() + "',to_date('" + txtMAdate.Text.Trim() + "','dd/mm/yyyy'),'" + lblPNo.Text.Trim() + "',to_date('" + lblPDt.Text + "','dd/mm/yyyy'),'" + lstClientType.SelectedValue + "','" + lblR_Code.Text.Trim() + "','" + DL_PO.SelectedValue + "','C')";
					OracleCommand myInsertCommand = new OracleCommand(Clientquery);
					myInsertCommand.Transaction = myTrans;
					myInsertCommand.Connection = conn1;
					myInsertCommand.ExecuteNonQuery();

					string str3 = "Select NVL(max(MA_SNO),0)+1 from VEND_PO_MA_DETAIL where CASE_NO='" + lblCasNo.Text.Trim() + "' and MA_NO='" + txtMAN.Text.Trim() + "' and to_char(MA_DT, 'dd/mm/yyyy')='" + txtMAdate.Text.Trim() + "'";
					OracleCommand myCommand = new OracleCommand();
					myCommand.CommandText = str3;
					myCommand.Transaction = myTrans;
					myCommand.Connection = conn1;
					int sno = Convert.ToInt32(myCommand.ExecuteScalar());
					Label_Sno.Text = Convert.ToString(sno);

					string myInsertQuery1 = "Insert Into VEND_PO_MA_DETAIL (CASE_NO,MA_SNO,MA_NO,MA_DT,MA_FIELD,MA_DESC,OLD_PO_VALUE,NEW_PO_VALUE,USER_ID,DATETIME,MA_STATUS) " +
						"values('" + lblCasNo.Text.Trim() + "','" + sno + "','" + txtMAN.Text.Trim() + "',to_date('" + txtMAdate.Text.Trim() + "','dd/mm/yyyy'),'" + Txt_MAF.Text + "','" + txtMAD.Text.Trim() + "','" + txtMAOV.Text.Trim() + "','" + txtMANV.Text.Trim() + "','" + Session["CLIENT"].ToString() + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),'P')";
					OracleCommand myInsertCommand1 = new OracleCommand(myInsertQuery1);
					myInsertCommand1.Transaction = myTrans;
					myInsertCommand1.Connection = conn1;
					myInsertCommand1.ExecuteNonQuery();

					upload_MA();


					myTrans.Commit();
					conn1.Close();
					DisplayAlert("Your Record is Saved!!!");
					fillgrid();
					btnSave.Visible = false;
					BtnExist.Visible = false;
					btnUpdate.Visible = false;

					//Reset();



				}

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect("Error_Form.aspx?err=" + str1);
			}
			finally
			{
				conn1.Close();
			}
		}

		void upload_MA()
		{
			if (File2.PostedFile != null && File2.PostedFile.ContentLength > 0)
			{
				string fn = "", MyFile = "", fx = "";
				string mdt = dateconcate(txtMAdate.Text.Trim());
				MyFile = lblCasNo.Text.Trim() + '_' + txtMAN.Text.Trim() + '_' + mdt;
				fn = System.IO.Path.GetFileName(File2.PostedFile.FileName);
				fx = System.IO.Path.GetExtension(File2.PostedFile.FileName).ToUpper().Substring(1);
				String SaveLocation = null;
				if (fx == "PDF")
				{
					SaveLocation = Server.MapPath("/RBS/VENDOR/MA/" + MyFile + ".PDF");
				}
				else
				{
					DisplayAlert("Kindly Upload PDF File only");
				}

				File2.PostedFile.SaveAs(SaveLocation);
				DisplayAlert("MA Uploaded!!!");

			}

		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		protected void btnUpdate_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn1.Open();
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				conn1.Close();
				conn1.Close();

				string Clientquery = "Update VEND_PO_MA_DETAIL set MA_FIELD='" + Txt_MAF.Text.Trim() + "',MA_DESC='" + txtMAD.Text.Trim() + "',OLD_PO_VALUE='" + txtMAOV.Text.Trim() + "',NEW_PO_VALUE='" + txtMANV.Text.Trim() + "',MA_STATUS='P' where CASE_NO='" + lblCasNo.Text.Trim() + "' and MA_NO='" + txtMAN.Text.Trim() + "' and to_char(MA_DT,'dd/mm/yyyy')='" + txtMAdate.Text.Trim() + "' and MA_SNO='" + Label_Sno.Text.Trim() + "'";
				OracleCommand ClientCommand = new OracleCommand();
				ClientCommand.CommandText = Clientquery;
				ClientCommand.Connection = conn1;
				conn1.Open();
				ClientCommand.ExecuteNonQuery();
				conn1.Close();
				DisplayAlert("Record is Update!!!");
				fillgrid();
				btnSave.Visible = false;
				btnUpdate.Visible = false;
				BtnExist.Visible = false;

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect("Error_Form.aspx?err=" + str1);
			}
			finally
			{
				conn1.Close();
			}

		}

		void Show_File()
		{
			string MyFile_ma;
			string mdt_ma = dateconcate(txtMAdate.Text.Trim());
			MyFile_ma = lblCasNo.Text.Trim() + '_' + txtMAN.Text.Trim() + '_' + mdt_ma;

			string fpath = Server.MapPath("/RBS/VENDOR/MA/" + MyFile_ma + ".PDF");
			if (File.Exists(fpath) == false)
			{
				File2.Visible = true;
				HyperLink1.Visible = false;
			}
			else
			{
				HyperLink1.Visible = true;
				HyperLink1.Text = MyFile_ma;
				HyperLink1.NavigateUrl = "/RBS/VENDOR/MA/" + MyFile_ma + ".PDF";
				File2.Visible = false;
			}

		}

		string dateconcate1(string dt)
		{
			string myYear, myMonth, myDay;

			myYear = dt.Substring(0, 4);
			myMonth = dt.Substring(4, 2);
			myDay = dt.Substring(6, 2);
			string dt2 = myDay + '/' + myMonth + '/' + myYear;
			return (dt2);
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

		protected void BtnExist_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn1.Open();
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				OracleTransaction myTrans1 = conn1.BeginTransaction();

				string str4 = "Select NVL(max(MA_SNO),0)+1 from VEND_PO_MA_DETAIL where CASE_NO='" + lblCasNo.Text.Trim() + "' and MA_NO='" + txtMAN.Text.Trim() + "' and to_char(MA_DT, 'dd/mm/yyyy')='" + txtMAdate.Text.Trim() + "'";
				OracleCommand myCommand1 = new OracleCommand();
				myCommand1.CommandText = str4;
				myCommand1.Transaction = myTrans1;
				myCommand1.Connection = conn1;
				int sno1 = Convert.ToInt32(myCommand1.ExecuteScalar());
				Label_Sno.Text = Convert.ToString(sno1);

				string myInsertQuery2 = "Insert Into VEND_PO_MA_DETAIL (CASE_NO,MA_SNO,MA_NO,MA_DT,MA_FIELD,MA_DESC,OLD_PO_VALUE,NEW_PO_VALUE,USER_ID,DATETIME,MA_STATUS) " +
					"values('" + lblCasNo.Text.Trim() + "','" + sno1 + "','" + txtMAN.Text.Trim() + "',to_date('" + txtMAdate.Text.Trim() + "','dd/mm/yyyy'),'" + Txt_MAF.Text + "','" + txtMAD.Text.Trim() + "','" + txtMAOV.Text.Trim() + "','" + txtMANV.Text.Trim() + "','" + Session["CLIENT"].ToString() + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),'P')";
				OracleCommand myInsertCommand2 = new OracleCommand(myInsertQuery2);
				myInsertCommand2.Transaction = myTrans1;
				myInsertCommand2.Connection = conn1;
				myInsertCommand2.ExecuteNonQuery();

				//upload_MA();

				myTrans1.Commit();
				conn1.Close();
				DisplayAlert("Your Record is Saved!!!");
				fillgrid();
				btnSave.Visible = false;
				btnUpdate.Visible = false;
				BtnExist.Visible = false;

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect("Error_Form.aspx?err=" + str1);
			}
			finally
			{
				conn1.Close();
			}

		}

		void fillgrid()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "select m.CASE_NO CASE_NO,m.PO_NO PO_NO,to_char(m.PO_DT,'dd/mm/yyyy')PO_DT,m.MA_NO MA_NO,to_char(m.MA_DT,'dd/mm/yyyy')MA_DT,m.RLY_NONRLY RLY_NONRLY,(decode(m.RLY_NONRLY,'R','Railway','P','Private','S','State Government','F','Foreign Railways','U','PSU')||'('||m.RLY_CD||')')RLY_CD,(decode(m.PO_OR_LETTER,'P','PO','L','Letter')) PO_OR_LETTER,d.MA_SNO MA_SNO,d.MA_FIELD MA_FIELD,(decode(d.MA_STATUS,'P','Pending','A','Approved','R','Return')) MA_STATUS from VEND_PO_MA_MASTER m,VEND_PO_MA_DETAIL d where m.Case_no=d.Case_no and m.ma_no= d.ma_no and m.ma_dt=d.ma_dt and m.CASE_NO='" + lblCasNo.Text.Trim() + "' and m.MA_NO='" + txtMAN.Text.Trim() + "' and to_char(m.MA_DT,'dd/mm/yyyy')='" + txtMAdate.Text.Trim() + "' AND m.PO_SRC='C'";

				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					DgPO1.Visible = false;
				}
				else
				{
					DgPO1.Visible = true;
					DgPO1.DataSource = dsP;
					DgPO1.DataBind();
					conn1.Close();
				}
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
				conn1.Close();
			}


		}


	}
}