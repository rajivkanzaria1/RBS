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

namespace RBS.IE_Form
{
	public partial class IE_Form : System.Web.UI.Page
	{
		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		string Action;
		int code = new int();
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		int ecode = 0;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelConfirm.Attributes.Add("OnClick", "JavaScript:del();");
			btnFCList.Attributes.Add("OnClick", "JavaScript:validate1();");
			DataSet dsP = new DataSet();
			DataSet dsP1 = new DataSet();
			DataSet dsP2 = new DataSet();
			DataSet dsP3 = new DataSet();

			if (Convert.ToString(Request.QueryString["IE_CD"]) == "")
			{
				code = 0;
			}
			else
			{
				code = Convert.ToInt32(Request.QueryString["IE_CD"]);
				Action = Convert.ToString(Request.QueryString["Action"]);

			}
			if (!(IsPostBack))
			{

				try
				{

					show_signature();

					AltIE();
					AltIE_TWO();
					AltIE_THREE();
					Cont_AltIE();
					conn1.Close();

					string str2 = "select I.CO_CD,NVL2(D.R_DESIGNATION,I.CO_NAME ||'/'|| D.R_DESIGNATION,I.CO_NAME) CO_NAME from T08_IE_CONTROLL_OFFICER I, T07_RITES_DESIG D where I.CO_DESIG =D.R_DESIG_CD and CO_REGION='" + Session["Region"].ToString() + "' ORDER BY CO_NAME";
					OracleDataAdapter da1 = new OracleDataAdapter(str2, conn1);
					OracleCommand myOracleCommand1 = new OracleCommand(str2, conn1);
					ListItem lst1;
					conn1.Open();
					da1.SelectCommand = myOracleCommand1;
					da1.Fill(dsP1, "Table");
					lst1 = new ListItem();
					for (int j = 0; j <= dsP1.Tables[0].Rows.Count - 1; j++)
					{
						lst1 = new ListItem();
						lst1.Text = dsP1.Tables[0].Rows[j]["CO_NAME"].ToString();
						lst1.Value = dsP1.Tables[0].Rows[j]["CO_CD"].ToString();
						lstCOCD.Items.Add(lst1);
					}
					lstCOCD.Items.Insert(0, "");
					conn1.Close();
					//lstCOCD.SelectedValue="";

					string str3 = "select * from T01_REGIONS";
					OracleDataAdapter da2 = new OracleDataAdapter(str3, conn1);
					OracleCommand myOracleCommand2 = new OracleCommand(str3, conn1);
					ListItem lst4;
					conn1.Open();
					da2.SelectCommand = myOracleCommand2;
					da2.Fill(dsP2, "Table");
					for (int j = 0; j <= dsP2.Tables[0].Rows.Count - 1; j++)
					{
						lst4 = new ListItem();
						lst4.Text = dsP2.Tables[0].Rows[j]["REGION"].ToString();
						lst4.Value = dsP2.Tables[0].Rows[j]["REGION_CODE"].ToString();
						lstRegion.Items.Add(lst4);
					}
					//lstRegion.Items.Insert(0,"");
					conn1.Close();
					string str4 = "select * from T07_RITES_DESIG ";
					OracleDataAdapter da3 = new OracleDataAdapter(str4, conn1);
					OracleCommand myOracleCommand3 = new OracleCommand(str4, conn1);
					//ListItem lst; 
					conn1.Open();
					da3.SelectCommand = myOracleCommand3;
					da3.Fill(dsP3, "Table");
					lstDesig.DataValueField = "R_DESIG_CD";
					lstDesig.DataTextField = "R_DESIGNATION";
					lstDesig.DataSource = dsP3;
					lstDesig.DataBind();
					//lstDesig.Items.Insert(0,"");]
					ListItem lst5 = new ListItem();
					lst5 = new ListItem();
					lst5.Text = "Mechanical";
					lst5.Value = "M";
					lstDept.Items.Add(lst5);
					lst5 = new ListItem();
					lst5.Text = "Electrical";
					lst5.Value = "E";
					lstDept.Items.Add(lst5);
					lst5 = new ListItem();
					lst5.Text = "Civil";
					lst5.Value = "C";
					lstDept.Items.Add(lst5);
					lst5 = new ListItem();
					lst5.Text = "Metallurgy";
					lst5.Value = "L";
					lstDept.Items.Add(lst5);
					lst5 = new ListItem();
					lst5.Text = "Textiles";
					lst5.Value = "T";
					lstDept.Items.Add(lst5);
					lst5 = new ListItem();
					lst5.Text = "Power Engineering";
					lst5.Value = "P";
					lstDept.Items.Add(lst5);
					ListItem lst2 = new ListItem();
					lst2.Text = "Local";
					lst2.Value = "LC";
					lstType.Items.Add(lst2);
					lst2 = new ListItem();
					lst2.Text = "Outstation";
					lst2.Value = "OU";
					lstType.Items.Add(lst2);
					lst2 = new ListItem();
					lst2.Text = "Liaison Officer";
					lst2.Value = "LO";
					lstType.Items.Add(lst2);
					lstType.Items.Insert(0, "");
					ListItem lst3 = new ListItem();
					lst3.Text = "Working";
					lst3.Value = "W";
					lstStatus.Items.Add(lst3);
					lst3 = new ListItem();
					lst3.Text = "Retired";
					lst3.Value = "R";
					lstStatus.Items.Add(lst3);
					lst3 = new ListItem();
					lst3.Text = "Transferred";
					lst3.Value = "T";
					lstStatus.Items.Add(lst3);
					lst3 = new ListItem();
					lst3.Text = "Left/Repatriated";
					lst3.Value = "L";
					lstStatus.Items.Add(lst3);


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
				if (Action == "M")
				{
					show();
					Label2.Visible = true;
					Label16.Visible = true;
					Label16.Text = code.ToString();
					btnSave.Enabled = true;
					btnDelConfirm.Visible = false;
					rbs.SetFocus(txtIEName);
				}
				else if (Action == "D")
				{

					show();
					Label2.Visible = true;
					Label16.Visible = true;
					Label16.Text = code.ToString();
					btnDelConfirm.Visible = true;
					btnDelConfirm.Enabled = true;
					btnSave.Visible = false;
					rbs.SetFocus(txtIEName);

				}
				else
				{
					Label2.Visible = false;
					Label16.Visible = false;
					btnSave.Visible = true;
					lstIECity.Visible = false;
					lstRegion.SelectedValue = Session["Region"].ToString();
				}
				//				show_signature();
				//				BindClusterName();
				//				AltIE();

			}

		}
		void AltIE()
		{
			OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			using (OracleCommand cmd = new OracleCommand("select IE_CD,IE_NAME from T09_IE where IE_REGION='" + Session["Region"].ToString() + "' and IE_STATUS IS NULL ORDER BY IE_NAME", conn))
			{
				conn.Open();
				Dropdownlist2.DataSource = cmd.ExecuteReader();
				Dropdownlist2.DataValueField = "IE_CD";
				Dropdownlist2.DataTextField = "IE_NAME";
				Dropdownlist2.DataBind();
				conn.Close();
				Dropdownlist2.Items.Insert(0, new ListItem("--Select ALT_IE Name--", "0"));
			}
		}


		void AltIE_TWO()
		{
			OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			using (OracleCommand cmd = new OracleCommand("select IE_CD,IE_NAME from T09_IE where IE_REGION='" + Session["Region"].ToString() + "' and IE_STATUS IS NULL ORDER BY IE_NAME", conn))
			{
				conn.Open();
				Dropdownlist1.DataSource = cmd.ExecuteReader();
				Dropdownlist1.DataValueField = "IE_CD";
				Dropdownlist1.DataTextField = "IE_NAME";
				Dropdownlist1.DataBind();
				conn.Close();
				Dropdownlist1.Items.Insert(0, new ListItem("--Select IE Name--", "0"));
			}
		}
		void Cont_AltIE()
		{
			OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			using (OracleCommand cmd = new OracleCommand("select IE_CD,IE_NAME from T09_IE where IE_REGION='" + Session["Region"].ToString() + "' and IE_STATUS IS NULL and IE_JOB_TYPE='C' ORDER BY IE_NAME", conn))
			{
				conn.Open();
				lstCont_Alt_IE.DataSource = cmd.ExecuteReader();
				lstCont_Alt_IE.DataValueField = "IE_CD";
				lstCont_Alt_IE.DataTextField = "IE_NAME";
				lstCont_Alt_IE.DataBind();
				conn.Close();
				lstCont_Alt_IE.Items.Insert(0, new ListItem("--Select IE Name--", "0"));
			}
		}
		void AltIE_THREE()
		{
			OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			using (OracleCommand cmd = new OracleCommand("select IE_CD,IE_NAME from T09_IE where IE_REGION='" + Session["Region"].ToString() + "' and IE_STATUS IS NULL ORDER BY IE_NAME", conn))
			{
				conn.Open();
				Dropdownlist3.DataSource = cmd.ExecuteReader();
				Dropdownlist3.DataValueField = "IE_CD";
				Dropdownlist3.DataTextField = "IE_NAME";
				Dropdownlist3.DataBind();
				conn.Close();
				Dropdownlist3.Items.Insert(0, new ListItem("--Select IE Name--", "0"));
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
		void show_signature()
		{
			string fpath1 = Server.MapPath("/RBS/IE/SIGNATURE/FULL/" + Label16.Text.Trim() + ".JPG");
			if (File.Exists(fpath1) == false)
			{
				Image1.Visible = false;
				File1.Visible = true;

			}
			else
			{
				Image1.ImageUrl = "/RBS/IE/SIGNATURE/FULL/" + Label16.Text.Trim() + ".JPG";
				File1.Visible = false;
				Image1.Visible = true;


			}

			string fpath2 = Server.MapPath("/RBS/IE/SIGNATURE/INITIALS/" + Label16.Text.Trim() + ".JPG");
			if (File.Exists(fpath2) == false)
			{
				Image2.Visible = false;
				File2.Visible = true;

			}
			else
			{
				Image2.ImageUrl = "/RBS/IE/SIGNATURE/INITIALS/" + Label16.Text.Trim() + ".JPG";
				File2.Visible = false;
				Image2.Visible = true;


			}

		}
		void upload_signature()
		{
			if (File1.PostedFile != null && File1.PostedFile.ContentLength > 0)
			{
				string fn = "", fx = "", MyFile = "";
				MyFile = Label16.Text.Trim();
				fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
				fx = System.IO.Path.GetExtension(File1.PostedFile.FileName).ToUpper().Substring(1);
				String SaveLocation = null;
				SaveLocation = Server.MapPath("IE/SIGNATURE/FULL/" + MyFile + ".JPG");
				File1.PostedFile.SaveAs(SaveLocation);
				DisplayAlert("Full Signature Uploaded!!!");


			}
			if (File2.PostedFile != null && File2.PostedFile.ContentLength > 0)
			{
				string fn = "", fx = "", MyFile = "";
				MyFile = Label16.Text.Trim();
				fn = System.IO.Path.GetFileName(File2.PostedFile.FileName);
				fx = System.IO.Path.GetExtension(File2.PostedFile.FileName).ToUpper().Substring(1);
				String SaveLocation = null;
				SaveLocation = Server.MapPath("IE/SIGNATURE/INITIALS/" + MyFile + ".JPG");
				File2.PostedFile.SaveAs(SaveLocation);
				DisplayAlert("Initials Uploaded!!!");

			}

		}



		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			String IE_CALLMARKING = null;

			int CD;
			conn1.Open();
			try
			{

				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH:MI:SS') from dual", conn1);
				string ss = Convert.ToString(cmd2.ExecuteScalar());

				string status, cocode, ccd;
				if ((lstStatus.SelectedValue == "W"))
				{
					status = "";
				}
				else
				{
					status = lstStatus.SelectedValue;
				}

				if ((lstCOCD.SelectedValue == ""))
				{
					cocode = "null";
				}
				else
				{
					cocode = lstCOCD.SelectedValue;
				}

				if ((lstIECity.SelectedValue == ""))
				{
					ccd = "null";
				}
				else
				{
					ccd = lstIECity.SelectedValue;
				}

				string ie_job_type = "";

				if (lstIEJobType.SelectedValue != "R")
				{
					ie_job_type = lstIEJobType.SelectedValue;
				}
				if (code == 0)
				{
					if (lstIECity.Visible == false)
					{
						DisplayAlert("Plz Press the select City button first and then save it");
					}
					else
					{
						if (txtSealNo.Text == "")
						{
							txtSealNo.Text = "null";
						}
						OracleCommand cmd = new OracleCommand("Select count(*) from T09_IE where IE_REGION='" + Session["Region"].ToString() + "' and (IE_SNAME='" + txtIESName.Text.Trim() + "' or IE_EMP_NO ='" + txtEmpNo.Text.Trim() + "')", conn1);
						int count = Convert.ToInt16(cmd.ExecuteScalar());
						if (count == 0)
						{
							string str3 = "select NVL(max(IE_CD),0) from T09_IE";
							OracleCommand myInsertCommand = new OracleCommand();
							myInsertCommand.CommandText = str3;
							myInsertCommand.Connection = conn1;
							CD = Convert.ToInt32(myInsertCommand.ExecuteScalar());
							code = CD + 1;
							string IEName = txtIEName.Text;
							string IESName = txtIESName.Text;
							string EmpNo = txtEmpNo.Text.Trim();
							string Desig = lstDesig.SelectedItem.Value;
							string sealNo = txtSealNo.Text;
							string Department = lstDept.SelectedItem.Value;
							string IEPNo = txtIEPno.Text;
							string Joiningdate = txtJoinDT.Text;
							string StusDate = txtStatusDT.Text;
							string IType = lstType.SelectedItem.Value;
							string Religion = lstRegion.SelectedItem.Value;
							string Email = txtIEEmail.Text.Trim();
							string Dob = txtIE_DOB.Text.Trim();

							string DDl2nd = Dropdownlist2.SelectedItem.Value;

							if (rdbIYes.Checked)
							{
								IE_CALLMARKING = "Y";
								IE_CALLMARKING = IE_CALLMARKING.Trim();

							}
							else if (rdbINo.Checked)
							{
								IE_CALLMARKING = "N";
								IE_CALLMARKING = IE_CALLMARKING.Trim();

							}

							string myInsertQuery = "INSERT INTO T09_IE(IE_CD,IE_NAME,IE_SNAME,IE_EMP_NO,IE_DESIG,IE_SEAL_NO,IE_DEPARTMENT,IE_CITY_CD,IE_PHONE_NO,IE_EMAIL,IE_CO_CD,IE_STATUS,IE_STATUS_DT,IE_TYPE,IE_REGION,IE_JOIN_DT,IE_DOB,ALT_IE,ALT_IE_TWO,ALT_IE_THREE,IE_CALL_MARKING,IE_PWD,USER_ID,DATETIME,CALL_MARKING_STOPPING_DT,IE_JOB_TYPE,CONT_ALT_IE) values(" + code + ", '" + txtIEName.Text + "', '" + txtIESName.Text.Trim() + "','" + txtEmpNo.Text.Trim() + "','" + lstDesig.SelectedItem.Value + "'," + txtSealNo.Text + ",'" + lstDept.SelectedItem.Value + "','" + ccd + "','" + txtIEPno.Text + "','" + txtIEEmail.Text.Trim() + "','" + cocode + "','" + status + "', to_date('" + txtStatusDT.Text + "','dd/mm/yyyy'),'" + lstType.SelectedItem.Value + "','" + lstRegion.SelectedItem.Value + "',to_date('" + txtJoinDT.Text + "','dd/mm/yyyy'),to_date('" + txtIE_DOB.Text.Trim() + "','dd/mm/yyyy'),'" + Dropdownlist2.SelectedItem.Value + "','" + Dropdownlist1.SelectedItem.Value + "','" + Dropdownlist3.SelectedItem.Value + "','" + IE_CALLMARKING + "','" + txtEmpNo.Text.Trim() + "','" + Session["Uname"].ToString() + "',to_date('" + ss + "','dd/mm/yyyy-HH:MI:SS'),to_date('" + txtCallStopDt.Text + "','dd/mm/yyyy-HH:MI:SS'),'" + ie_job_type + "'," + lstCont_Alt_IE.SelectedValue + ")";
							myInsertCommand.CommandText = myInsertQuery;
							myInsertCommand.Connection = conn1;
							myInsertCommand.ExecuteNonQuery();
							conn1.Close();
							Label2.Visible = true;
							Label16.Visible = true;
							Label16.Text = code.ToString();
							btnSave.Visible = true;
							btnSave.Enabled = false;
							DisplayAlert("Your Record Has Been Saved!!!");
						}
						else
						{
							DisplayAlert("IE with Same Employee Short Name or Employee No. Already Exists!!!");
						}
						//Response.Redirect(("IE_Form.aspx"));
					}
				}
				else
				{
					if (txtSealNo.Text == "")
					{
						txtSealNo.Text = "null";
					}

					if (rdbIYes.Checked)
					{
						IE_CALLMARKING = "Y";
						IE_CALLMARKING = IE_CALLMARKING.Trim();

					}
					else if (rdbINo.Checked)
					{
						IE_CALLMARKING = "N";
						IE_CALLMARKING = IE_CALLMARKING.Trim();

					}

					OracleCommand myUpdateCommand = new OracleCommand();
					string myUpdateQuery = "Update T09_IE set IE_NAME ='" + txtIEName.Text + "', IE_SNAME ='" + txtIESName.Text.Trim() + "',IE_EMP_NO ='" + txtEmpNo.Text.Trim() + "',IE_DESIG = " + lstDesig.SelectedItem.Value + ",IE_SEAL_NO =" + txtSealNo.Text + ",IE_DEPARTMENT = '" + lstDept.SelectedItem.Value + "',IE_CITY_CD=" + ccd + ", IE_PHONE_NO='" + txtIEPno.Text + "', IE_CO_CD=" + cocode + ",IE_STATUS = '" + status + "',IE_STATUS_DT=to_date('" + txtStatusDT.Text + "','dd/mm/yyyy'),IE_TYPE='" + lstType.SelectedItem.Value + "', IE_REGION='" + lstRegion.SelectedItem.Value + "', IE_JOIN_DT=to_date('" + txtJoinDT.Text + "','dd/mm/yyyy'),IE_PWD='" + txtEmpNo.Text.Trim() + "',USER_ID='" + Session["Uname"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH:MI:SS'),IE_EMAIL='" + txtIEEmail.Text.Trim() + "',IE_DOB=to_date('" + txtIE_DOB.Text.Trim() + "','dd/mm/yyyy'),ALT_IE= " + Dropdownlist2.SelectedItem.Value + ",ALT_IE_TWO= " + Dropdownlist1.SelectedItem.Value + ",ALT_IE_THREE= " + Dropdownlist3.SelectedItem.Value + ",IE_CALL_MARKING='" + IE_CALLMARKING + "',CALL_MARKING_STOPPING_DT=TO_DATE('" + txtCallStopDt.Text + "','dd/mm/yyyy'), IE_JOB_TYPE='" + ie_job_type + "', CONT_ALT_IE=" + lstCont_Alt_IE.SelectedValue + " where IE_CD=" + code;
					myUpdateCommand.CommandText = myUpdateQuery;
					myUpdateCommand.Connection = conn1;
					int count = myUpdateCommand.ExecuteNonQuery();
					if ((count == 0))
					{
						throw new System.Exception("No Record Found!!! The Record has been  Deleted by other User While you were Modifying the Data");
					}
					conn1.Close();
					btnSave.Visible = true;
					DisplayAlert("Your Record Has Been Updated And IE Password Has Been Reset To His Employee No. so, Plz Inform Him!!!");
					//Response.Redirect(("IE_Form.aspx"));
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




			//			txtIECD.Text = ""; 
			//			txtIEName.Text = ""; 
			//			txtIESName.Text = ""; 
			//			txtSealNo.Text="";
			//			txtStatusDT.Text="";
			//			txtEmpNo.Text="";
			//			txtIEPno.Text = ""; 

			//btnSave.Enabled = false; 

		}
		void show()
		{
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "select IE_CD, IE_NAME,IE_SNAME,IE_EMP_NO,IE_DESIG,IE_SEAL_NO,IE_DEPARTMENT,IE_CITY_CD,IE_PHONE_NO,IE_EMAIL,IE_CO_CD,NVL(IE_STATUS,'W') IE_STATUS,TO_CHAR(IE_STATUS_DT,'dd/mm/yyyy')IE_STATUS_DT,IE_TYPE,IE_REGION,to_char(IE_JOIN_DT,'dd/mm/yyyy') IE_JOIN_DT,to_char(IE_DOB,'dd/mm/yyyy') DOB,ALT_IE,IE_CALL_MARKING,ALT_IE_TWO,ALT_IE_THREE,CONT_ALT_IE,to_char(CALL_MARKING_STOPPING_DT,'DD/MM/YYYY') CALL_STOP_DT, IE_JOB_TYPE from T09_IE where IE_CD=" + code;
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				conn1.Close();
				if (dsP.Tables[0].Rows.Count == 0)
				{
					throw new System.Exception("No Record Found!!! For The Given IE Code.");
				}
				else
				{

					//txtIECD.Text = dsP.Tables[0].Rows[0]["IE_CD"].ToString(); 
					txtIEName.Text = dsP.Tables[0].Rows[0]["IE_NAME"].ToString();
					txtIESName.Text = dsP.Tables[0].Rows[0]["IE_SNAME"].ToString();
					txtEmpNo.Text = dsP.Tables[0].Rows[0]["IE_EMP_NO"].ToString();
					lstDesig.SelectedValue = dsP.Tables[0].Rows[0]["IE_DESIG"].ToString();
					txtSealNo.Text = dsP.Tables[0].Rows[0]["IE_SEAL_NO"].ToString();
					lstDept.SelectedValue = dsP.Tables[0].Rows[0]["IE_DEPARTMENT"].ToString();

					string str = "select CITY_CD,NVL2(LOCATION,LOCATION||' : '||CITY,CITY) CITY from T03_CITY where CITY_CD=" + dsP.Tables[0].Rows[0]["IE_CITY_CD"].ToString();

					fillCity(str);
					txtCity.Text = lstIECity.SelectedValue;
					lstIECity.SelectedValue = dsP.Tables[0].Rows[0]["IE_CITY_CD"].ToString();
					txtIEPno.Text = dsP.Tables[0].Rows[0]["IE_PHONE_NO"].ToString();
					txtIEEmail.Text = dsP.Tables[0].Rows[0]["IE_EMAIL"].ToString();
					lstCOCD.SelectedValue = dsP.Tables[0].Rows[0]["IE_CO_CD"].ToString();
					lstStatus.SelectedValue = dsP.Tables[0].Rows[0]["IE_STATUS"].ToString();
					txtStatusDT.Text = dsP.Tables[0].Rows[0]["IE_STATUS_DT"].ToString();
					lstType.SelectedValue = dsP.Tables[0].Rows[0]["IE_TYPE"].ToString();
					lstRegion.SelectedValue = dsP.Tables[0].Rows[0]["IE_REGION"].ToString();
					txtJoinDT.Text = dsP.Tables[0].Rows[0]["IE_JOIN_DT"].ToString();
					txtIE_DOB.Text = dsP.Tables[0].Rows[0]["DOB"].ToString();
					txtCallStopDt.Text = dsP.Tables[0].Rows[0]["CALL_STOP_DT"].ToString();
					if (dsP.Tables[0].Rows[0]["IE_JOB_TYPE"].ToString() == string.Empty)
					{
						lstIEJobType.SelectedValue = "R";
					}
					else
					{
						lstIEJobType.SelectedValue = dsP.Tables[0].Rows[0]["IE_JOB_TYPE"].ToString();
					}
					if (dsP.Tables[0].Rows[0]["ALT_IE"].ToString() == string.Empty)
					{
						AltIE();
					}
					else
					{
						Dropdownlist2.SelectedValue = dsP.Tables[0].Rows[0]["ALT_IE"].ToString();

					}
					if (dsP.Tables[0].Rows[0]["ALT_IE_TWO"].ToString() == string.Empty)
					{
						AltIE_TWO();
					}
					else
					{
						Dropdownlist1.SelectedValue = dsP.Tables[0].Rows[0]["ALT_IE_TWO"].ToString();

					}
					if (dsP.Tables[0].Rows[0]["ALT_IE_THREE"].ToString() == string.Empty)
					{
						AltIE_THREE();
					}
					else
					{
						Dropdownlist3.SelectedValue = dsP.Tables[0].Rows[0]["ALT_IE_THREE"].ToString();

					}
					if (dsP.Tables[0].Rows[0]["CONT_ALT_IE"].ToString() == string.Empty)
					{
						Cont_AltIE();
					}
					else
					{
						lstCont_Alt_IE.SelectedValue = dsP.Tables[0].Rows[0]["CONT_ALT_IE"].ToString();

					}
					if (dsP.Tables[0].Rows[0]["IE_CALL_MARKING"].ToString() == "Y")
					{
						rdbIYes.Checked = true;
					}
					else
					{
						rdbINo.Checked = true;
					}


					//Dropdownlist2.SelectedValue = dsP.Tables[0].Rows[0]["ALT_IE"].ToString(); 
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
		protected void btnDelConfirm_Click(object sender, System.EventArgs e)
		{
			try
			{
				string myDeleteQuery = "Delete T09_IE where IE_CD=" + code;
				OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
				myOracleCommand.Connection = conn1;
				conn1.Open();
				myOracleCommand.ExecuteNonQuery();
				conn1.Close();
				//			txtIECD.Text = ""; 
				//			txtIEName.Text = ""; 
				//			txtIESName.Text = ""; 
				//			txtIEPno.Text = ""; 
				//			txtSealNo.Text="";
				//			txtStatusDT.Text="";
				//			txtEmpNo.Text="";
				btnSave.Visible = true;
				btnSave.Enabled = false;

				btnDelConfirm.Visible = false;
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
			Response.Redirect(("IE_Form.aspx"));
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("IE_Search_Form.aspx");
		}

		int fillCity(string str1)
		{
			//string str1=str;
			DataSet dsP = new DataSet();
			OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			ListItem lst;
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			conn1.Close();
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
					lst.Text = dsP.Tables[0].Rows[i]["CITY"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["CITY_CD"].ToString();
					lstIECity.Items.Add(lst);
				}
				lstIECity.SelectedIndex = 0;
				lstIECity.Visible = true;
				//rbs.SetFocus(lstIECity);
				ecode = 2;
				return (ecode);
			}


		}
		protected void btnFCList_Click(object sender, System.EventArgs e)
		{
			lstIECity.Items.Clear();
			lstIECity.Visible = true;

			try
			{
				if ((Convert.ToInt64(txtCity.Text) >= 1) && (Convert.ToInt64(txtCity.Text) <= 9999))
				{
					string str1 = "select CITY_CD,NVL2(LOCATION,LOCATION||' : '||CITY,CITY) CITY from T03_CITY where CITY_CD= " + txtCity.Text + " Order by CITY ";
					int a = fillCity(str1);
					if (a == 1)
					{
						lstIECity.Visible = false;
						DisplayAlert("No City Found!!!");
						rbs.SetFocus(txtCity);
					}
					else if (a == 2)
					{
						//Response.Write("<script language=JavaScript> document.Form1.lstIECity.setfocus(); </script>");
						rbs.SetFocus(lstIECity);

					}


				}
				else
				{
					DisplayAlert("Invalid City Code!!!");
					lstIECity.Items.Clear();
					lstIECity.Visible = false;
					rbs.SetFocus(txtCity);

				}

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = "Input string was not in a correct format.";
				if (str.Equals(str1))
				{
					string str2 = "select CITY_CD,NVL2(LOCATION,LOCATION||' : '||CITY,CITY) CITY from T03_CITY where TRIM(UPPER(CITY)) LIKE TRIM(UPPER('" + txtCity.Text + "%')) Order by CITY ";
					int a = fillCity(str2);
					if (a == 1)
					{
						lstIECity.Visible = false;
						DisplayAlert("No City Found!!!");
						rbs.SetFocus(txtCity);
					}
					else if (a == 2)
					{
						txtCity.Text = lstIECity.SelectedValue;
						rbs.SetFocus(lstIECity);
						//	Response.Write("<script language=JavaScript> document.Form1.lstIECity.setfocus(); </script>");
					}

					//lblCity.Text=lstVendCity.SelectedItem.Text;
				}
				else
				{
					string str2 = str.Replace("\n", "");
					Response.Redirect("Error_Form.aspx?err=" + str2);
				}

			}
			finally
			{
				conn1.Close();
			}
		}

		protected void lstIECity_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtCity.Text = lstIECity.SelectedValue;
			rbs.SetFocus(lstRegion);
		}

		protected void btnUpload_Click(object sender, System.EventArgs e)
		{
			upload_signature();
		}

		protected void Dropdownlist1_SelectedIndexChanged(object sender, System.EventArgs e)
		{

		}

	}
}