using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.RKM_PurchesOrder_Form
{
	public class PurchesOrder_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		OracleDataReader dr;

		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnPODetails;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Label lblCaseNo;
		protected System.Web.UI.WebControls.Label lblPurchCode;
		protected System.Web.UI.WebControls.DropDownList ddlPurcherCode;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.DropDownList ddlSNS;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblRailwayCode;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.TextBox txtPOLst5;
		protected System.Web.UI.WebControls.Label lblMinFee;
		protected System.Web.UI.WebControls.TextBox txtMinFee;
		protected System.Web.UI.WebControls.Label lblMaxFee;
		protected System.Web.UI.WebControls.TextBox txtMaxFee;
		protected System.Web.UI.WebControls.Label lblContNo;
		protected System.Web.UI.WebControls.TextBox txtCNO;
		protected System.Web.UI.WebControls.Label lblContDate;
		protected System.Web.UI.WebControls.TextBox txtConDate;
		protected System.Web.UI.WebControls.Label lblProjectRef;
		protected System.Web.UI.WebControls.TextBox txtProjRef;
		protected System.Web.UI.WebControls.DropDownList ddlSrvTax;
		protected System.Web.UI.WebControls.Label lblSvrToBeIncluded;
		static string caseno;
		protected System.Web.UI.WebControls.Label lblCasNo;
		string ss, ptype, rtype, bcd;
		int ccd;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.DropDownList ddlVender;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtPON;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtPOdate;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.TextBox txtDatePOrites;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddlPOLetter;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected Tittle.Controls.CustomDataGrid grdCB;
		protected System.Web.UI.WebControls.Button btnDelCB;
		protected System.Web.UI.WebControls.Button btnSaveCB;
		protected System.Web.UI.WebControls.DropDownList ddlBPOCode;
		protected System.Web.UI.WebControls.Label lblBPOCode;
		protected System.Web.UI.WebControls.Label lblFirmCD;
		protected System.Web.UI.WebControls.Label lblFirm;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Button btnFCList;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox txtVend;
		protected System.Web.UI.WebControls.Label lblRailway;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Label lblRCD;
		protected System.Web.UI.WebControls.Button btnSBPO;
		protected System.Web.UI.WebControls.TextBox txtSBPO;
		protected System.Web.UI.WebControls.TextBox txtSPur;
		protected System.Web.UI.WebControls.Button btnSPur;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.Label lblConsigneeCD;
		protected System.Web.UI.WebControls.TextBox txtSCon;
		protected System.Web.UI.WebControls.Button btnSCon;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.DropDownList ddlConsigneeCD;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.TextBox txtPORemarks;
		int ecode = 0;

		private void Page_Load(object sender, System.EventArgs e)
		{
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelete.Attributes.Add("OnClick", "JavaScript:conformation();");
			btnFCList.Attributes.Add("OnClick", "JavaScript:validate1();");
			btnSaveCB.Attributes.Add("OnClick", "JavaScript:validate2();");
			btnSPur.Attributes.Add("OnClick", "JavaScript:validate3(txtSPur);");
			btnSCon.Attributes.Add("OnClick", "JavaScript:validate3(txtSCon);");
			btnSBPO.Attributes.Add("OnClick", "JavaScript:validate3(txtSBPO);");

			if (!IsPostBack)
			{
				if (Convert.ToString(Request.QueryString["case_no"]) == null || Convert.ToString(Request.QueryString["case_no"]) == "")
				{
					//fill_Rly();
					//fill_vendor();
					fill_Region(Session["Region"].ToString());
					btnDelete.Visible = false;
					btnPODetails.Visible = false;
					ptype = Request.QueryString["PO_TYPE"];
					lblRCD.Text = Convert.ToString(Request.QueryString["RLY_CD"]);
					if (ptype == "R")
					{
						rtype = Request.QueryString["RLY_CD"];
						po_type(ptype, rtype);
					}
					else
					{
						rtype = Request.QueryString["RLY_CD"];
						po_type(ptype, rtype);
					}
					fill_consignee_purcher();
					//fill_ConsigneeCd();
					//fill_BPOcd();
					cbVisible(0);
					conn1.Open();
					OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy')from dual", conn1);
					ss = Convert.ToString(cmd2.ExecuteScalar());
					conn1.Close();
					txtDatePOrites.Text = ss;
					ddlVender.Visible = false;
					ddlPOLetter.SelectedValue = "P";
				}
				else
				{
					string action = Request.QueryString["Action"];
					//lblCasNo.Enabled=false;
					casenofalse();
					string case_no = Request.QueryString["case_no"].ToString();
					lblCasNo.Text = case_no;
					//fill_Rly();
					//fill_vendor();
					search();
					fill_ConsigneeCd();
					fill_BPOcd();
					//search();
					fillgrid();
					//Request.QueryString ["Serial_No"]!= null
					if (Request.QueryString["CONSIGNEE_CD"] != null)
					{

						ccd = Convert.ToInt32(Request.QueryString["CONSIGNEE_CD"]);
						bcd = Convert.ToString(Request.QueryString["BPO_CD"]);
						repopulate_con_cd(ccd.ToString());
						txtSCon.Visible = false;
						btnSCon.Visible = false;
						Label15.Visible = false;
						//ddlConsigneeCD.SelectedValue=ccd.ToString();
						ddlConsigneeCD.Enabled = false;
						txtSCon.Visible = false;
						btnSCon.Visible = false;
						repopulate_bpo_cd(bcd.ToString());
						//ddlBPOCode.SelectedValue=bcd;
						btnDelCB.Visible = true;
						btnSaveCB.Text = "Save Consignee:BPO";
					}
					else
					{
						ddlConsigneeCD.Enabled = true;
						btnDelCB.Visible = false;
						btnSaveCB.Text = "Add Consignee:BPO";
					}

					//fill_Region(Session["Region"].ToString());
					//po_type();

					if (action == "M")
					{
						btnDelete.Visible = false;
						btnSave.Visible = true;
						//btnPODetails.Visible=true;
						txtPOdate.Enabled = false;
						//txtDatePOrites.Enabled=false;

					}
					else if (action == "D")
					{
						btnSave.Visible = false;
						btnDelete.Visible = true;
						//btnPODetails.Visible=false;
					}
					else
					{
						txtPOdate.Enabled = false;
					}

					if (Session["Role"].ToString() == "General User")
					{
						btnDelete.Visible = false;
						btnSave.Visible = false;
						//btnPODetails.Visible=true;
						txtPOdate.Enabled = false;
						btnFCList.Visible = false;
						btnSPur.Visible = false;
						btnSCon.Visible = false;
						btnSBPO.Visible = false;
						btnSaveCB.Visible = false;
						btnDelCB.Visible = false;
						//txtDatePOrites.Enabled=false;
					}

				}
			}
			//ddlRegionCode.SelectedValue=Session["Region"].ToString();


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
			this.btnFCList.Click += new System.EventHandler(this.btnFCList_Click);
			this.ddlVender.SelectedIndexChanged += new System.EventHandler(this.ddlVender_SelectedIndexChanged_1);
			this.btnSPur.Click += new System.EventHandler(this.btnSPur_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.btnSCon.Click += new System.EventHandler(this.btnSCon_Click);
			this.btnSBPO.Click += new System.EventHandler(this.btnSBPO_Click);
			this.btnSaveCB.Click += new System.EventHandler(this.btnSaveCB_Click);
			this.btnDelCB.Click += new System.EventHandler(this.btnDelCB_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.btnPODetails.Click += new System.EventHandler(this.btnPODetails_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		// ------------------ Filling Record in Railway Field ------------------ //
		public void generate()
		{
			try
			{
				string myYear, myMonth, mYr, myYr;
				string recdt = txtPOdate.Text.ToString();
				//myYear=DateTime.Now.Year.ToString();
				//myMonth=DateTime.Now.Month.ToString();
				myYear = recdt.Substring(6, 4);
				myMonth = recdt.Substring(3, 2);
				mYr = myYear.ToString();
				myYr = mYr.Substring(2, 2);
				if (myMonth.Length == 1)
				{
					myMonth = 0 + myMonth;
				}
				else
				{
					myMonth = myMonth;
				}
				string region = Session["Region"].ToString();
				string ffive = region + myYr + myMonth;
				string str3 = "Select lpad(nvl(max(to_number(nvl(substr(CASE_NO,6,4),0))),0)+1,4,'0') from T13_PO_MASTER where REGION_CODE ='" + region + "' and substr(CASE_NO,1,5)='" + ffive + "'";
				OracleCommand myInsertCommand = new OracleCommand(str3, conn1);
				str3 = Convert.ToString(myInsertCommand.ExecuteScalar());
				lblCasNo.Text = ffive + str3;
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}

		}
		// ------------------ Button Save Function ------------------ //
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			conn1.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH:MI:SS') from dual", conn1);
			ss = Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();
			if (lblCasNo.Text == "")
			{

				save();

			}
			else
			{
				update();
			}
			rbs.SetFocus(txtSCon);
			//btnSave.Visible=false;


			//lblCasNo.Enabled=false;

			//fill_ConsigneeCd();
			//fill_BPOcd();
		}
		// ------------------ Saving Record in Tables ------------------ //
		public void save()
		{
			conn1.Open();

			OracleCommand cmddt = new OracleCommand("SELECT sign(sysdate - TO_DATE('" + txtPOdate.Text.Trim() + "','DD/MM/YYYY')) FROM dual", conn1);
			int ss_err = Convert.ToInt32(cmddt.ExecuteScalar());


			if (ddlVender.Visible == false)
			{
				DisplayAlert("Plz Press the [select Vendor] button first and then save it");
			}
			else if (ss_err != 1)
			{
				DisplayAlert("PO Date Cannot Be Greater Then Current Date!!!");
			}
			else
			{
				OracleCommand cmd = null;
				try
				{

					cmd = new OracleCommand("GENERATE_CASE_NO", conn1);
					cmd.CommandType = CommandType.StoredProcedure;

					OracleParameter prm1 = new OracleParameter("IN_REGION_CD", OracleDbType.Char);
					prm1.Direction = ParameterDirection.Input;
					prm1.Value = Session["REGION"];
					cmd.Parameters.Add(prm1);

					OracleParameter prm2 = new OracleParameter("IN_PO_DT", OracleDbType.Varchar2);
					prm2.Direction = ParameterDirection.Input;
					prm2.Value = Convert.ToString(txtPOdate.Text);
					cmd.Parameters.Add(prm2);

					OracleParameter prm3 = new OracleParameter("OUT_CASE_NO", OracleDbType.Char, 9);
					prm3.Direction = ParameterDirection.Output;
					cmd.Parameters.Add(prm3);

					OracleParameter prm4 = new OracleParameter("OUT_ERR_CD", OracleDbType.Int32);
					prm4.Direction = ParameterDirection.Output;
					cmd.Parameters.Add(prm4);

					cmd.ExecuteNonQuery();
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

				if (Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value) == -1)
				{
					DisplayAlert("Unable To Create the CASE_NO, So Plz Try Again.");
				}
				else
				{
					lblCasNo.Text = Convert.ToString(cmd.Parameters["OUT_CASE_NO"].Value);

					if (Label8.Text == "Railways")
					{
						//						generate();
						//lblFirm.Text=ddlRCode.SelectedItem.Text;
						//lblFirmCD.Text=ddlRCode.SelectedValue;
						lblFirm.Text = lblRailway.Text;
						lblFirmCD.Text = lblRailwayCode.Text;
						//OracleCommand cmd1 =new OracleCommand ("insert into T13_PO_MASTER values ('" + lblCasNo.Text + "','" + ddlPurcherCode.SelectedItem.Value + "','" + ddlSNS.SelectedItem.Value + "','R','" + ddlPOLetter.SelectedItem.Value + "','" + txtPON.Text + "','" + txtPOLst5.Text + "',to_date('" + txtPOdate.Text + "','dd/mm/yy'),to_date('" + txtDatePOrites.Text + "','dd/mm/yy'),'" + ddlVender.SelectedItem.Value + "','" + lblRCD.Text + "','" + Session["Region"].ToString() + "','"+Session["Uname"]+"', to_date('" +ss+ "','dd/mm/yyyy-HH:MI:SS'))",conn1);	
						try
						{
							conn1.Open();
							OracleCommand cmd1 = new OracleCommand("update T13_PO_MASTER set STOCK_NONSTOCK = '" + ddlSNS.SelectedItem.Value + "',RLY_NONRLY='R',PO_OR_LETTER = '" + ddlPOLetter.SelectedItem.Value + "',PO_NO = '" + txtPON.Text + "',PO_DT=to_date('" + txtPOdate.Text + "','dd/mm/yyyy'),L5NO_PO = '" + txtPOLst5.Text + "',PURCHASER_CD='" + ddlPurcherCode.SelectedValue + "',RECV_DT=to_date('" + txtDatePOrites.Text + "','dd/mm/yyyy'),VEND_CD = '" + ddlVender.SelectedItem.Value + "',RLY_CD='" + lblRCD.Text + "',REGION_CODE='" + Session["Region"].ToString() + "',REMARKS='" + txtPORemarks.Text.Trim() + "',USER_ID='" + Session["UName"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH:MI:SS') where CASE_NO = '" + lblCasNo.Text + "'", conn1);
							cmd1.ExecuteNonQuery();
							conn1.Close();
							caseno = lblCasNo.Text;
							btnSave.Visible = false;
							lblCaseNo.Visible = true;
							lblCasNo.Visible = true;
							lblCasNo.Text = caseno;
							Label10.Visible = true;
							//btnPODetails.Visible=true;

							cbVisible(1);
							DisplayAlert("Your Record Has Been Saved!!!");
						}
						catch (Exception)
						{
							OracleCommand cmderr = new OracleCommand("delete from T13_PO_MASTER where CASE_NO = '" + lblCasNo.Text + "'", conn1);
							cmderr.ExecuteNonQuery();
							lblCasNo.Text = "";
							DisplayAlert("Unable To Create the CASE_NO, So Plz Try Again.");
						}
						fill_ConsigneeCd();
						fill_BPOcd();
						//				string popupScript = "<script language='javascript'>" + "window.open('PopUp.aspx?str=Your Record Has Been Saved,and Your Case No is:-"+ caseno +"', 'CustomPopUp', " + "'width=350, height=125, menubar=no, resizable=no')" + "</script>";
						//				Page.RegisterStartupScript("PopupScript", popupScript);
					}
					else if (Label8.Text != "Railways")
					{
						//						generate();
						lblFirm.Text = Label8.Text;
						lblFirmCD.Text = lblRailwayCode.Text;
						//OracleCommand cmd2 =new OracleCommand ("insert into T13_PO_MASTER values ('" + lblCasNo.Text + "','" + ddlPurcherCode.SelectedItem.Value + "','" + ddlSNS.SelectedItem.Value + "','" + lblRailwayCode.Text + "','" + ddlPOLetter.SelectedItem.Value + "','" + txtPON.Text + "','" + txtPOLst5.Text + "',to_date('" + txtPOdate.Text + "','dd/mm/yy'),to_date('" + txtDatePOrites.Text + "','dd/mm/yy'),'" + ddlVender.SelectedItem.Value + "','"+lblRCD.Text+"','" + Session["Region"].ToString() + "','"+Session["Uname"]+"', to_date('" +ss+ "','dd/mm/yyyy-HH:MI:SS'))",conn1);	
						try
						{
							conn1.Open();
							OracleCommand cmd2 = new OracleCommand("update T13_PO_MASTER set STOCK_NONSTOCK = '" + ddlSNS.SelectedItem.Value + "',RLY_NONRLY='" + lblRailwayCode.Text + "',PO_OR_LETTER = '" + ddlPOLetter.SelectedItem.Value + "',PO_NO = '" + txtPON.Text + "',PO_DT=to_date('" + txtPOdate.Text + "','dd/mm/yyyy'),L5NO_PO = '" + txtPOLst5.Text + "',PURCHASER_CD='" + ddlPurcherCode.SelectedValue + "',RECV_DT=to_date('" + txtDatePOrites.Text + "','dd/mm/yyyy'),VEND_CD = '" + ddlVender.SelectedItem.Value + "',RLY_CD='" + lblRCD.Text + "',REGION_CODE='" + Session["Region"].ToString() + "',REMARKS='" + txtPORemarks.Text.Trim() + "',USER_ID='" + Session["UName"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH:MI:SS') where CASE_NO = '" + lblCasNo.Text + "'", conn1);
							cmd2.ExecuteNonQuery();
							OracleCommand cmd3 = new OracleCommand("insert into T14A_PO_NONRLY values ('" + lblCasNo.Text + "','" + txtCNO.Text + "',to_date('" + txtConDate.Text + "','dd/mm/yyyy'),'" + txtProjRef.Text + "','" + txtMinFee.Text + "','" + txtMaxFee.Text + "','" + ddlSrvTax.SelectedItem.Value + "')", conn1);
							cmd3.ExecuteNonQuery();
							conn1.Close();
							caseno = lblCasNo.Text;
							btnSave.Visible = false;
							lblCaseNo.Visible = true;
							lblCasNo.Visible = true;
							lblCasNo.Text = caseno;
							Label10.Visible = true;
							//btnPODetails.Visible=true;
							cbVisible(1);
							DisplayAlert("Your Record Has Been Saved!!!");

						}
						catch (Exception)
						{
							OracleCommand cmderr2 = new OracleCommand("delete from T14A_PO_NONRLY where CASE_NO = '" + lblCasNo.Text + "'", conn1);
							cmderr2.ExecuteNonQuery();

							OracleCommand cmderr1 = new OracleCommand("delete from T13_PO_MASTER where CASE_NO = '" + lblCasNo.Text + "'", conn1);
							cmderr1.ExecuteNonQuery();
							lblCasNo.Text = "";
							DisplayAlert("Unable To Create the CASE_NO, So Plz Try Again.");
						}
						fill_ConsigneeCd();
						fill_BPOcd();
					}

				}
			}

		}
		// ------------------ Updating Record in Tables ------------------ //
		public void update()
		{
			if (ddlVender.Visible == false)
			{
				DisplayAlert("Plz Press the select Vendor button first and then save it");
			}
			else
			{
				try
				{
					//					OracleCommand cmd=new OracleCommand("select CASE_NO from T14A_PO_NONRLY where CASE_NO='" + lblCasNo.Text + "'",conn1);

					//					int check=0;
					//					OracleDataReader reader = cmd.ExecuteReader();
					//					while(reader.Read())
					//					{
					//						if (Convert.ToString(reader["CASE_NO"]).Trim() == lblCasNo.Text.Trim())
					//						{
					//							check =1;
					//							break;
					//						}
					//						else
					//						{
					//							check = 0;
					//						}
					//					}

					conn1.Open();
					if (Label8.Text == "Railways")
					{
						OracleCommand cmd4 = new OracleCommand("update T13_PO_MASTER set STOCK_NONSTOCK = '" + ddlSNS.SelectedItem.Value + "',PO_OR_LETTER = '" + ddlPOLetter.SelectedItem.Value + "',PO_NO = '" + txtPON.Text + "',RECV_DT=to_date('" + txtDatePOrites.Text + "','dd/mm/yyyy'),L5NO_PO = '" + txtPOLst5.Text + "',PURCHASER_CD='" + ddlPurcherCode.SelectedValue + "',VEND_CD = '" + ddlVender.SelectedItem.Value + "',REMARKS='" + txtPORemarks.Text.Trim() + "',USER_ID='" + Session["UName"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH:MI:SS') where CASE_NO = '" + lblCasNo.Text + "'", conn1);
						cmd4.ExecuteNonQuery();
						caseno = lblCasNo.Text;
						DisplayAlert("Your Record Has Been Updated!!!");
					}
					else if (Label8.Text != "Railways")
					{
						casenofalse();
						OracleCommand cmd5 = new OracleCommand("update T13_PO_MASTER set STOCK_NONSTOCK = '" + ddlSNS.SelectedItem.Value + "',PO_OR_LETTER = '" + ddlPOLetter.SelectedItem.Value + "', PO_NO = '" + txtPON.Text + "',RECV_DT=to_date('" + txtDatePOrites.Text + "','dd/mm/yyyy'), L5NO_PO = '" + txtPOLst5.Text + "',PURCHASER_CD='" + ddlPurcherCode.SelectedValue + "',VEND_CD = '" + ddlVender.SelectedItem.Value + "',REMARKS='" + txtPORemarks.Text.Trim() + "',USER_ID='" + Session["UName"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH:MI:SS') where CASE_NO = '" + lblCasNo.Text + "'", conn1);
						cmd5.ExecuteNonQuery();
						OracleCommand cmd6 = new OracleCommand("update T14A_PO_NONRLY set CONTRACT_NO = '" + txtCNO.Text + "',CONTRACT_DT = to_date('" + txtConDate.Text + "','dd/mm/yyyy'),PROJECT_REF = '" + txtProjRef.Text + "', MIN_FEE = '" + txtMinFee.Text + "',MAX_FEE = '" + txtMaxFee.Text + "',WITH_SERV_TAX = '" + ddlSrvTax.SelectedItem.Value + "' where  CASE_NO = '" + lblCasNo.Text + "'", conn1);
						cmd6.ExecuteNonQuery();
						caseno = lblCasNo.Text;
						DisplayAlert("Your Record Has Been Updated!!!");
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
				//			 else if((ddlRNR.SelectedValue)!=("R").ToString()&& check !=1)
				//			{ 
				//				casenofalse();
				//				OracleCommand cmd5 =new OracleCommand ("update T13_PO_MASTER set STOCK_NONSTOCK = '" + ddlSNS.SelectedItem.Value + "',RLY_NONRLY = '" + ddlRNR.SelectedItem.Value + "',PO_OR_LETTER = '" + ddlPOLetter.SelectedItem.Value + "',PO_NO = '" + txtPON.Text + "', L5NO_PO = '" + txtPOLst5.Text + "', PO_DT = to_date('" + txtPOdate.Text + "','dd/mm/yyyy'), RECV_DT = to_date('" + txtDatePOrites.Text + "','dd/mm/yyyy'),VEND_CD = '" + ddlVender.SelectedItem.Value + "',RLY_CD ='',USER_ID='"+Session["UName"] +"', DATETIME=to_date('" +ss+ "','dd/mm/yyyy-HH:MI:SS') where CASE_NO = '" + lblCasNo.Text + "'",conn1);
				//				cmd5.ExecuteNonQuery(); 
				//				OracleCommand cmd6 =new OracleCommand ("insert into T14_PO_NONRLY values ('" + lblCasNo.Text + "', '" + txtCNO.Text + "', to_date('" + txtConDate.Text + "','dd/mm/yy'), '" + txtProjRef.Text + "','" + txtMinFee.Text + "','" + txtMaxFee.Text + "','" + ddlSrvTax.SelectedItem.Value + "')",conn1);
				//				cmd6.ExecuteNonQuery();
				//				caseno=lblCasNo.Text;
				//				string popupScript1 = "<script language='javascript'>" + "window.open('PopUp.aspx?str=Your Record Has Been Updated" +"', 'CustomPopUp', " + "'width=350, height=100, menubar=no, resizable=no')" + "</script>";
				//				Page.RegisterStartupScript("PopupScript", popupScript1);
				//			}
				conn1.Close();
				btnSave.Visible = true;
				lblCaseNo.Visible = true;
				lblCasNo.Visible = true;
				lblCasNo.Text = caseno;
				//btnPODetails.Visible=true;
				fill_ConsigneeCd();
				fill_BPOcd();
				Label10.Visible = true;
			}
		}
		public void casenofalse()
		{
			lblCaseNo.Visible = true;
			lblCasNo.Visible = true;
			//lblCasNo.Enabled=false;
		}
		// ------------------ Searching Record ------------------ //
		public void search()
		{
			try
			{
				DataSet reader = new DataSet();
				string str1 = "select CASE_NO,PURCHASER_CD,STOCK_NONSTOCK,RLY_NONRLY,PO_OR_LETTER,PO_NO,L5NO_PO,to_char(PO_DT,'dd/mm/yyyy')PO_DT,to_char(RECV_DT,'dd/mm/yyyy')RECV_DT,VEND_CD,RLY_CD,REGION_CODE,REMARKS from T13_PO_MASTER where CASE_NO='" + lblCasNo.Text + "'";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand cmd = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = cmd;
				da.Fill(reader, "Table");
				conn1.Close();
				//OracleDataReader reader = cmd.ExecuteReader();

				lblCasNo.Text = Convert.ToString(reader.Tables[0].Rows[0]["CASE_NO"]);

				ddlSNS.SelectedValue = Convert.ToString(reader.Tables[0].Rows[0]["STOCK_NONSTOCK"]);

				ddlPOLetter.SelectedValue = Convert.ToString(reader.Tables[0].Rows[0]["PO_OR_LETTER"]);
				if (Convert.ToString(reader.Tables[0].Rows[0]["RLY_NONRLY"]) == "R")
				{

					//lblRailwayCode.Visible=true;
					//ddlRCode.Visible=true;
					//ddlRCode.SelectedValue = Convert.ToString(reader["RLY_CD"]);

					lblRailwayCode.Text = Convert.ToString(reader.Tables[0].Rows[0]["RLY_NONRLY"]);
					lblRCD.Text = Convert.ToString(reader.Tables[0].Rows[0]["RLY_CD"]);
					conn1.Close();
					po_type(lblRailwayCode.Text, lblRCD.Text);
					//po_type(Convert.ToString(reader.Tables[0].Rows[0]["RLY_CD"]));
					//lblFirm.Text=ddlRCode.SelectedItem.Text;
					//lblFirmCD.Text=ddlRCode.SelectedValue;
					lblFirm.Text = lblRailway.Text;
					lblFirmCD.Text = Convert.ToString(reader.Tables[0].Rows[0]["RLY_CD"]);
					//Label8.Visible=true;
					//ddlRNR.Visible=false;
					//Label8.Text="Railway";
				}
				else if (Convert.ToString(reader.Tables[0].Rows[0]["RLY_NONRLY"]) != "R")
				{
					visible();
					Label10.Visible = true;
					//Label8.Visible=false;
					//ddlRNR.Visible=true;
					lblRailwayCode.Text = Convert.ToString(reader.Tables[0].Rows[0]["RLY_NONRLY"]);
					lblRCD.Text = Convert.ToString(reader.Tables[0].Rows[0]["RLY_CD"]);
					po_type(lblRailwayCode.Text, lblRCD.Text);
					//po_type(Convert.ToString(reader.Tables[0].Rows[0]["RLY_NONRLY"]));
					//ddlRNR.SelectedValue = Convert.ToString(reader["RLY_NONRLY"]);
					//lblFirm.Text=ddlRNR.SelectedItem.Text;
					//lblFirmCD.Text=ddlRNR.SelectedValue;
					lblFirm.Text = Label8.Text;
					lblFirmCD.Text = Convert.ToString(reader.Tables[0].Rows[0]["RLY_NONRLY"]);
					OracleCommand cmd1 = new OracleCommand("select CONTRACT_NO,TO_CHAR(CONTRACT_DT,'dd/mm/yyyy')CONTRACT_DT,PROJECT_REF,MIN_FEE,MAX_FEE,WITH_SERV_TAX from T14A_PO_NONRLY where CASE_NO='" + lblCasNo.Text + "'", conn1);
					conn1.Open();
					OracleDataReader reader1 = cmd1.ExecuteReader();
					while (reader1.Read())
					{
						txtCNO.Text = Convert.ToString(reader1["CONTRACT_NO"]);
						txtConDate.Text = Convert.ToString(reader1["CONTRACT_DT"]);
						txtProjRef.Text = Convert.ToString(reader1["PROJECT_REF"]);
						txtMinFee.Text = Convert.ToString(reader1["MIN_FEE"]);
						txtMaxFee.Text = Convert.ToString(reader1["MAX_FEE"]);
						ddlSrvTax.SelectedValue = Convert.ToString(reader1["WITH_SERV_TAX"]);
					}
					conn1.Close();
				}
				//fill_consignee_purcher();
				//ddlPurcherCode.SelectedValue = Convert.ToString(reader.Tables[0].Rows[0]["PURCHASER_CD"]);
				repopulate_pur_cd(Convert.ToString(reader.Tables[0].Rows[0]["PURCHASER_CD"]));
				txtPON.Text = Convert.ToString(reader.Tables[0].Rows[0]["PO_NO"]);
				txtPOLst5.Text = Convert.ToString(reader.Tables[0].Rows[0]["L5NO_PO"]);
				txtPOdate.Text = Convert.ToString(reader.Tables[0].Rows[0]["PO_DT"]);
				txtPORemarks.Text = Convert.ToString(reader.Tables[0].Rows[0]["REMARKS"]);
				txtDatePOrites.Text = Convert.ToString(reader.Tables[0].Rows[0]["RECV_DT"]);
				string str2 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and trim(VEND_CD)=" + Convert.ToString(reader.Tables[0].Rows[0]["VEND_CD"]) + " and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME";
				fill_vendor(str2);
				ddlVender.SelectedValue = Convert.ToString(reader.Tables[0].Rows[0]["VEND_CD"]);
				txtVend.Text = Convert.ToString(reader.Tables[0].Rows[0]["VEND_CD"]);
				//vendor_status(ddlVender.SelectedValue);
				fill_Region(Convert.ToString(reader.Tables[0].Rows[0]["REGION_CODE"]));




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
		// ------------------ Deleting Record from Tables ------------------ //
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			conn1.Open();
			try
			{
				OracleCommand cmdcall = new OracleCommand("select nvl(count(CASE_NO),0) from T17_CALL_REGISTER where CASE_NO='" + lblCasNo.Text + "'", conn1);
				int delstatus = Convert.ToInt16(cmdcall.ExecuteScalar());
				if (delstatus == 0)
				{
					OracleCommand cmd = new OracleCommand("select CASE_NO from T15_PO_DETAIL where CASE_NO='" + lblCasNo.Text + "'", conn1);
					int check = 0;
					OracleDataReader reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						if (Convert.ToString(reader["CASE_NO"]).Trim() == lblCasNo.Text.Trim())
						{
							check = 1;
						}
						else
						{
							check = 0;
						}
					}
					reader.Close();

					if (Label8.Text == "Railways" && check != 1)
					{
						casenofalse();
						OracleCommand cmd8 = new OracleCommand("delete T13_PO_MASTER where CASE_NO = '" + lblCasNo.Text + "'", conn1);
						cmd8.ExecuteNonQuery();
						OracleCommand cmd9 = new OracleCommand("delete T14_PO_BPO where CASE_NO = '" + lblCasNo.Text + "'", conn1);
						cmd9.ExecuteNonQuery();
						clear();
						//					string popupScript = "<script language='javascript'>" + "window.open('PopUp.aspx?str=Your Record Has Been Deleted!!!', 'CustomPopUp', " + "'width=350, height=100, menubar=no, resizable=no')" + "</script>";
						//					Page.RegisterStartupScript("PopupScript", popupScript);
					}
					else if (Label8.Text != "Railways" && check != 1)
					{
						casenofalse();
						OracleCommand cmd1 = new OracleCommand("delete T14A_PO_NONRLY where CASE_NO = '" + lblCasNo.Text + "'", conn1);
						cmd1.ExecuteNonQuery();
						OracleCommand cmd2 = new OracleCommand("delete T13_PO_MASTER where CASE_NO = '" + lblCasNo.Text + "'", conn1);
						cmd2.ExecuteNonQuery();
						OracleCommand cmd10 = new OracleCommand("delete T14_PO_BPO where CASE_NO = '" + lblCasNo.Text + "'", conn1);
						cmd10.ExecuteNonQuery();
						clear();
						//					string popupScript = "<script language='javascript'>" + "window.open('PopUp.aspx?str=Your Record Has Been Deleted!!!', 'CustomPopUp', " + "'width=350, height=100, menubar=no, resizable=no')" + "</script>";
						//					Page.RegisterStartupScript("PopupScript", popupScript);
					}
					else if (Label8.Text == "Railways" && check == 1)
					{
						casenofalse();
						OracleCommand cmd3 = new OracleCommand("delete T15_PO_DETAIL where CASE_NO = '" + lblCasNo.Text + "'", conn1);
						cmd3.ExecuteNonQuery();
						OracleCommand cmd4 = new OracleCommand("delete T13_PO_MASTER where CASE_NO = '" + lblCasNo.Text + "'", conn1);
						cmd4.ExecuteNonQuery();
						OracleCommand cmd11 = new OracleCommand("delete T14_PO_BPO where CASE_NO = '" + lblCasNo.Text + "'", conn1);
						cmd11.ExecuteNonQuery();
						clear();
						//					string popupScript = "<script language='javascript'>" + "window.open('PopUp.aspx?str=Your Record Has Been Deleted!!!', 'CustomPopUp', " + "'width=350, height=100, menubar=no, resizable=no')" + "</script>";
						//					Page.RegisterStartupScript("PopupScript", popupScript);
					}
					else if (Label8.Text != "Railways" && check == 1)
					{
						casenofalse();
						OracleCommand cmd5 = new OracleCommand("delete T15_PO_DETAIL where CASE_NO = '" + lblCasNo.Text + "'", conn1);
						cmd5.ExecuteNonQuery();
						OracleCommand cmd6 = new OracleCommand("delete T14A_PO_NONRLY where CASE_NO = '" + lblCasNo.Text + "'", conn1);
						cmd6.ExecuteNonQuery();
						OracleCommand cmd7 = new OracleCommand("delete T13_PO_MASTER where CASE_NO = '" + lblCasNo.Text + "'", conn1);
						cmd7.ExecuteNonQuery();
						OracleCommand cmd9 = new OracleCommand("delete T14_PO_BPO where CASE_NO = '" + lblCasNo.Text + "'", conn1);
						cmd9.ExecuteNonQuery();
						clear();
						//					string popupScript = "<script language='javascript'>" + "window.open('PopUp.aspx?str=Your Record Has Been Deleted!!!', 'CustomPopUp', " + "'width=350, height=100, menubar=no, resizable=no')" + "</script>";
						//					Page.RegisterStartupScript("PopupScript", popupScript);
					}
				}
				else
				{
					DisplayAlert("This PO Cannot Be Deleted, Because their is a Call Present for this Case No.");
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
		// ------------------ Select Change Effects on Vender Field ------------------ //

		//		public void fill_Rly()
		//		{
		//				ddlRCode.Items.Clear();
		//				DataSet dsP = new DataSet();
		//				string str1 = "select RLY_CD,RAILWAY from T91_RAILWAYS"; 
		//				OracleDataAdapter da = new OracleDataAdapter(str1, conn1); 
		//				OracleCommand myOracleCommand = new OracleCommand(str1, conn1); 
		//				ListItem lst; 
		//				da.SelectCommand = myOracleCommand; 
		//				da.Fill(dsP, "Table"); 
		//				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++) 
		//				{ 
		//					lst = new ListItem(); 
		//					lst.Text = dsP.Tables[0].Rows[i]["RAILWAY"].ToString(); 
		//					lst.Value = dsP.Tables[0].Rows[i]["RLY_CD"].ToString();
		//					ddlRCode.Items.Add(lst); 
		//				} 
		//			ddlRCode.Items.Insert(0,"");
		//		}
		// ------------------ Filling Record in Vender Field ------------------ //
		int fill_vendor(string str1)
		{
			ddlVender.Items.Clear();
			DataSet dsP = new DataSet();
			//string str1 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and (trim(upper(VEND_CD))=upper('"+vend.Trim()+"') or trim(upper(VEND_NAME)) LIKE upper('"+vend.Trim()+"%')) and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME"; 
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
					lst.Text = dsP.Tables[0].Rows[i]["VEND_NAME"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["VEND_CD"].ToString();
					ddlVender.Items.Add(lst);
				}
				ddlVender.Visible = true;
				ddlVender.SelectedIndex = 0;
				//rbs.SetFocus(ddlVender);
				ecode = 2;
				return (ecode);

			}

		}
		// ------------------ Filling Record in Purcher/Consignee Field ------------------ //
		public void fill_consignee_purcher()
		{
			try
			{
				ddlPurcherCode.Items.Clear();
				DataSet dsP = new DataSet();
				string str1;
				if (Label8.Text == "Railways")
				{
					//str1 = "select CONSIGNEE_CD,(nvl2(trim(CONSIGNEE_FIRM),trim(CONSIGNEE_FIRM)||'/','')||nvl2(trim(CONSIGNEE_DESIG),trim(CONSIGNEE_DESIG)||'/','')||nvl2(trim(CONSIGNEE_DEPT),trim(CONSIGNEE_DEPT)||'/','')||CITY)  CONSIGNEE_NAME from T06_CONSIGNEE WHERE CONSIGNEE_FIRM='"+lblRCD.Text+"' ORDER BY CONSIGNEE_NAME"; 
					str1 = "select A.CONSIGNEE_CD,(A.CONSIGNEE_CD||'-'||nvl2(trim(A.CONSIGNEE_FIRM),trim(A.CONSIGNEE_FIRM)||'/','')||nvl2(trim(A.CONSIGNEE_DESIG),trim(CONSIGNEE_DESIG)||'/','')||nvl2(trim(A.CONSIGNEE_DEPT),trim(A.CONSIGNEE_DEPT)||'/','')||NVL2(trim(A.CONSIGNEE_ADD1),trim(A.CONSIGNEE_ADD1)||'/','')||NVL2(trim(B.LOCATION),trim(B.LOCATION)||' : '||trim(B.CITY),trim(B.CITY)))  CONSIGNEE_NAME from T06_CONSIGNEE A, T03_CITY B WHERE A.CONSIGNEE_CITY=B.CITY_CD and upper(trim(A.CONSIGNEE_FIRM))=upper(trim('" + lblRCD.Text + "')) ORDER BY (nvl2(trim(A.CONSIGNEE_DESIG),trim(A.CONSIGNEE_DESIG)||'/','')||nvl2(trim(A.CONSIGNEE_DEPT),trim(A.CONSIGNEE_DEPT)||'/','')||nvl2(trim(A.CONSIGNEE_FIRM),trim(A.CONSIGNEE_FIRM)||'/','')||NVL2(trim(A.CONSIGNEE_ADD1),trim(A.CONSIGNEE_ADD1)||'/','')||NVL2(trim(B.LOCATION),trim(B.LOCATION)||' : '||trim(B.CITY),trim(B.CITY)))";
				}
				else
				{
					//str1 = "select CONSIGNEE_CD,(nvl2(trim(CONSIGNEE_FIRM),trim(CONSIGNEE_FIRM)||'/','')||nvl2(trim(CONSIGNEE_DESIG),trim(CONSIGNEE_DESIG)||'/','')||trim(CONSIGNEE_DEPT))  CONSIGNEE_NAME from T06_CONSIGNEE WHERE CONSIGNEE_TYPE='"+lblRailwayCode.Text+"' ORDER BY CONSIGNEE_NAME"; 
					str1 = "select A.CONSIGNEE_CD,(A.CONSIGNEE_CD||'-'||nvl2(trim(A.CONSIGNEE_FIRM),trim(A.CONSIGNEE_FIRM)||'/','')||nvl2(trim(A.CONSIGNEE_DESIG),trim(CONSIGNEE_DESIG)||'/','')||nvl2(trim(A.CONSIGNEE_DEPT),trim(A.CONSIGNEE_DEPT)||'/','')||NVL2(trim(A.CONSIGNEE_ADD1),trim(A.CONSIGNEE_ADD1)||'/','')||NVL2(trim(B.LOCATION),trim(B.LOCATION)||' : '||trim(B.CITY),trim(B.CITY)))  CONSIGNEE_NAME from T06_CONSIGNEE A, T03_CITY B WHERE A.CONSIGNEE_CITY=B.CITY_CD and A.CONSIGNEE_TYPE='" + lblRailwayCode.Text + "' ORDER BY (nvl2(trim(A.CONSIGNEE_DESIG),trim(A.CONSIGNEE_DESIG)||'/','')||nvl2(trim(A.CONSIGNEE_DEPT),trim(A.CONSIGNEE_DEPT)||'/','')||nvl2(trim(A.CONSIGNEE_FIRM),trim(A.CONSIGNEE_FIRM)||'/','')||NVL2(trim(A.CONSIGNEE_ADD1),trim(A.CONSIGNEE_ADD1)||'/','')||NVL2(trim(B.LOCATION),trim(B.LOCATION)||' : '||trim(B.CITY),trim(B.CITY)))";
				}
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				ListItem lst;
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					lst = new ListItem();
					lst.Text = dsP.Tables[0].Rows[i]["CONSIGNEE_NAME"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["CONSIGNEE_CD"].ToString();
					ddlPurcherCode.Items.Add(lst);
				}
				ddlPurcherCode.Items.Insert(0, "");
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}
		}

		public void fill_ConsigneeCd()
		{
			try
			{
				//				ptype= Request.Params["PO_TYPE"].ToString();
				ddlConsigneeCD.Items.Clear();
				DataSet dsP = new DataSet();
				//string str1 = "select CONSIGNEE_CD,CONSIGNEE_S_NAME from T06_CONSIGNEE where CONSIGNEE_TYPE='"+ptype+"' ORDER BY CONSIGNEE_S_NAME"; 
				string str1;


				if (Label8.Text == "Railways")
				{
					//str1 = "select A.CONSIGNEE_CD,(nvl2(trim(A.CONSIGNEE_DESIG),trim(A.CONSIGNEE_DESIG)||'/','')||nvl2(trim(A.CONSIGNEE_DEPT),trim(A.CONSIGNEE_DEPT)||'/','')||nvl2(trim(A.CONSIGNEE_FIRM),trim(A.CONSIGNEE_FIRM)||'/','')||B.CITY) CONSIGNEE_NAME from T06_CONSIGNEE A, T03_CITY B WHERE A.CONSIGNEE_CITY=B.CITY_CD and upper(trim(A.CONSIGNEE_FIRM))=upper(trim('"+lblRCD.Text+"')) ORDER BY CONSIGNEE_NAME"; 
					str1 = "select A.CONSIGNEE_CD,(A.CONSIGNEE_CD||'-'||nvl2(trim(A.CONSIGNEE_DESIG),trim(A.CONSIGNEE_DESIG)||'/','')||nvl2(trim(A.CONSIGNEE_DEPT),trim(A.CONSIGNEE_DEPT)||'/','')||nvl2(trim(A.CONSIGNEE_FIRM),trim(A.CONSIGNEE_FIRM)||'/','')||NVL2(trim(A.CONSIGNEE_ADD1),trim(A.CONSIGNEE_ADD1)||'/','')||NVL2(trim(B.LOCATION),trim(B.LOCATION)||' : '||trim(B.CITY),trim(B.CITY))) CONSIGNEE_NAME from T06_CONSIGNEE A, T03_CITY B WHERE A.CONSIGNEE_CITY=B.CITY_CD and upper(trim(A.CONSIGNEE_FIRM))=upper(trim('" + lblRCD.Text + "')) ORDER BY (nvl2(trim(A.CONSIGNEE_DESIG),trim(A.CONSIGNEE_DESIG)||'/','')||nvl2(trim(A.CONSIGNEE_DEPT),trim(A.CONSIGNEE_DEPT)||'/','')||nvl2(trim(A.CONSIGNEE_FIRM),trim(A.CONSIGNEE_FIRM)||'/','')||NVL2(trim(A.CONSIGNEE_ADD1),trim(A.CONSIGNEE_ADD1)||'/','')||NVL2(trim(B.LOCATION),trim(B.LOCATION)||' : '||trim(B.CITY),trim(B.CITY)))";
				}
				else
				{
					//str1 = "select A.CONSIGNEE_CD,(nvl2(trim(A.CONSIGNEE_DESIG),trim(A.CONSIGNEE_DESIG)||'/','')||nvl2(trim(A.CONSIGNEE_DEPT),trim(A.CONSIGNEE_DEPT)||'/','')||nvl2(trim(A.CONSIGNEE_FIRM),trim(A.CONSIGNEE_FIRM)||'/','')||B.CITY) CONSIGNEE_NAME from T06_CONSIGNEE A, T03_CITY B WHERE A.CONSIGNEE_CITY=B.CITY_CD and A.CONSIGNEE_TYPE='"+lblRailwayCode.Text+"' ORDER BY CONSIGNEE_NAME"; 
					str1 = "select A.CONSIGNEE_CD,(A.CONSIGNEE_CD||'-'||nvl2(trim(A.CONSIGNEE_DESIG),trim(A.CONSIGNEE_DESIG)||'/','')||nvl2(trim(A.CONSIGNEE_DEPT),trim(A.CONSIGNEE_DEPT)||'/','')||nvl2(trim(A.CONSIGNEE_FIRM),trim(A.CONSIGNEE_FIRM)||'/','')||NVL2(trim(A.CONSIGNEE_ADD1),trim(A.CONSIGNEE_ADD1)||'/','')||NVL2(trim(B.LOCATION),trim(B.LOCATION)||' : '||trim(B.CITY),trim(B.CITY))) CONSIGNEE_NAME from T06_CONSIGNEE A, T03_CITY B WHERE A.CONSIGNEE_CITY=B.CITY_CD and A.CONSIGNEE_TYPE='" + lblRailwayCode.Text + "' ORDER BY (nvl2(trim(A.CONSIGNEE_DESIG),trim(A.CONSIGNEE_DESIG)||'/','')||nvl2(trim(A.CONSIGNEE_DEPT),trim(A.CONSIGNEE_DEPT)||'/','')||nvl2(trim(A.CONSIGNEE_FIRM),trim(A.CONSIGNEE_FIRM)||'/','')||NVL2(trim(A.CONSIGNEE_ADD1),trim(A.CONSIGNEE_ADD1)||'/','')||NVL2(trim(B.LOCATION),trim(B.LOCATION)||' : '||trim(B.CITY),trim(B.CITY)))";
				}

				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				ListItem lst;
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					lst = new ListItem();
					lst.Text = dsP.Tables[0].Rows[i]["CONSIGNEE_NAME"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["CONSIGNEE_CD"].ToString();
					ddlConsigneeCD.Items.Add(lst);
				}
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}
		}
		public void fill_BPOcd()
		{

			try
			{
				//string rly_cd= Request.Params["RLY_CD"].ToString();
				ddlBPOCode.Items.Clear();
				DataSet dsP = new DataSet();
				string str1;

				//				if(Label8.Text=="Railways")
				//				{
				//					str1 = "select BPO_CD,(BPO_NAME||'/'||BPO_RLY||'/'||BPO_ADD) BPO_NAME from T12_BILL_PAYING_OFFICER where BPO_RLY='"+lblRailwayCode.Text+"' and RLY_CD='"+rly_cd+"' and BPO_REGION='"+Session["REGION"]+"' ORDER BY BPO_NAME"; 
				//				}
				//				else
				//				{
				//str1 = "select BPO_CD,(BPO_NAME||'/'||BPO_RLY||'/'||BPO_ADD) BPO_NAME from T12_BILL_PAYING_OFFICER where BPO_TYPE='"+lblRailwayCode.Text+"' and BPO_RLY='"+lblRCD.Text+"' and BPO_REGION='"+Session["REGION"]+"' ORDER BY BPO_NAME"; 
				//str1 = "select BPO_CD,(trim(BPO_NAME)||'/'||trim(BPO_RLY)||'/'||trim(BPO_ADD)) BPO_NAME from T12_BILL_PAYING_OFFICER where BPO_TYPE='"+lblRailwayCode.Text+"' and upper(trim(BPO_RLY))=upper(trim('"+lblRCD.Text+"')) ORDER BY BPO_NAME"; 
				str1 = "select BPO_CD,(B.BPO_CD||'-'||B.BPO_NAME||'/'||B.BPO_RLY||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)) BPO_NAME from T12_BILL_PAYING_OFFICER B, T03_CITY C where B.BPO_CITY_CD=C.CITY_CD and BPO_TYPE='" + lblRailwayCode.Text + "' and upper(trim(BPO_RLY))=upper(trim('" + lblRCD.Text + "')) ORDER BY B.BPO_NAME";
				//				}
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				ListItem lst;
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					lst = new ListItem();
					lst.Text = dsP.Tables[0].Rows[i]["BPO_NAME"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["BPO_CD"].ToString();
					ddlBPOCode.Items.Add(lst);
				}
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}
		}
		public void po_type(string ptype, string rtype)
		{
			//ptype=Request.QueryString["PO_TYPE"];
			if (ptype == "P" || ptype == "F" || ptype == "U" || ptype == "S")
			{
				//				ListItem lst5 = new ListItem(); 
				//				lst5 = new ListItem(); 
				//				lst5.Text = "Private"; 
				//				lst5.Value = "P"; 
				//				ddlRNR.Items.Add(lst5); 
				//				lst5 = new ListItem(); 
				//				lst5.Text = "Foreign Railway"; 
				//				lst5.Value = "F"; 
				//				ddlRNR.Items.Add(lst5); 
				//				lst5 = new ListItem(); 
				//				lst5.Text = "PSU"; 
				//				lst5.Value = "U"; 
				//				ddlRNR.Items.Add(lst5); 
				//				lst5 = new ListItem(); 
				//				lst5.Text = "State Government"; 
				//				lst5.Value = "S"; 
				//				ddlRNR.Items.Add(lst5); 
				//				ddlRNR.Visible=true;
				//				Label8.Visible=false;
				Label8.Visible = true;
				lblRailway.Visible = false;
				lblRailway.Visible = true;
				lblRCD.Visible = false;
				if (ptype == "P")
				{
					Label8.Text = "Private";
					lblRailwayCode.Text = "P";
					lblRailway.Text = " (" + rtype + ") ";
					lblRCD.Text = rtype;

				}
				else if (ptype == "F")
				{
					Label8.Text = "Foreign Railway";
					lblRailwayCode.Text = "F";
					lblRailway.Text = " (" + rtype + ") ";
					lblRCD.Text = rtype;

				}
				else if (ptype == "U")
				{
					Label8.Text = "PSU";
					lblRailwayCode.Text = "U";
					lblRailway.Text = " (" + rtype + ") ";
					lblRCD.Text = rtype;

				}
				else if (ptype == "S")
				{
					Label8.Text = "State Government";
					lblRailwayCode.Text = "S";
					lblRailway.Text = " (" + rtype + ") ";
					lblRCD.Text = rtype;

				}
				visible();

			}
			else
			{
				//ddlRNR.Visible=false;
				Label8.Visible = true;
				Label8.Text = "Railways";
				string str1 = "select RAILWAY from T91_RAILWAYS where RLY_CD='" + rtype + "'";
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				string rcd = Convert.ToString(myOracleCommand.ExecuteScalar());
				conn1.Close();
				lblRCD.Visible = false;
				lblRailway.Visible = true;
				lblRailway.Text = " (" + rcd + ")";
				lblRailwayCode.Text = ptype;
				lblRCD.Text = rtype;
			}

		}

		// ------------------ Filling Region Code Field ------------------ //
		//		public void fill_Region()
		//		{
		//			try
		//			{
		//				ddlRegionCode.Items.Clear();
		//				DataSet dsP = new DataSet();
		//				string str1 = "select REGION_CODE,REGION from T01_REGIONS "; 
		//				OracleDataAdapter da = new OracleDataAdapter(str1, conn1); 
		//				OracleCommand myOracleCommand = new OracleCommand(str1, conn1); 
		//				ListItem lst; 
		//				da.SelectCommand = myOracleCommand; 
		//				da.Fill(dsP, "Table"); 
		//				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++) 
		//				{ 
		//					lst = new ListItem(); 
		//					lst.Text = dsP.Tables[0].Rows[i]["REGION"].ToString(); 
		//					lst.Value = dsP.Tables[0].Rows[i]["REGION_CODE"].ToString();
		//					ddlRegionCode.Items.Add(lst); 
		//				} 
		//				
		//			}
		//			catch(Exception ex)
		//			{
		//				string str;
		//				str = ex.Message;
		//				string str1=str.Replace("\n","");
		//				Response.Redirect(("Error_Form.aspx?err=" + str1));
		//			}
		//		}


		public void fill_Region(string reg)
		{
			try
			{
				if (reg == "N")
				{
					Label9.Text = "Northern Region";
				}
				else if (reg == "S")
				{
					Label9.Text = "Southern Region";
				}
				else if (reg == "E")
				{
					Label9.Text = "Eastern Region";
				}
				else if (reg == "W")
				{
					Label9.Text = "Western Region";
				}
				else if (reg == "C")
				{
					Label9.Text = "Central Region";
				}



			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}
		}


		private void btnPODetails_Click(object sender, System.EventArgs e)
		{
			caseno = lblCasNo.Text;
			string pt;
			//			if(Label8.Visible)
			//			{
			//				pt=ddlRCode.SelectedValue;
			//			}
			//			else
			//			{
			//				pt=ddlRNR.SelectedValue;
			//			}
			pt = lblRailwayCode.Text;
			Response.Redirect("PurchesOrderDetails.aspx?CASE_NO=" + caseno + "&type=" + pt + "&PODT=" + txtPOdate.Text.Trim());
		}
		// ------------------ Clearing Fields ------------------ //
		public void clear()
		{
			lblCasNo.Text = "";
			txtPON.Text = "";
			txtPOLst5.Text = "";
			txtPOdate.Text = "";
			txtDatePOrites.Text = "";
			txtCNO.Text = "";
			txtConDate.Text = "";
			txtProjRef.Text = "";
			txtMinFee.Text = "";
			txtMaxFee.Text = "";
			//fill_Rly();
			//fill_vendor();
			fill_consignee_purcher();
			//fill_Region();
		}
		public void visible()
		{
			//lblRailwayCode.Visible=false;
			//ddlRCode.Visible=false;
			lblContNo.Visible = true;
			txtCNO.Visible = true;
			lblProjectRef.Visible = true;
			txtProjRef.Visible = true;
			lblContDate.Visible = true;
			txtConDate.Visible = true;
			lblMinFee.Visible = true;
			txtMinFee.Visible = true;
			lblMaxFee.Visible = true;
			txtMaxFee.Visible = true;
			lblSvrToBeIncluded.Visible = true;
			ddlSrvTax.Visible = true;
		}

		public void cbVisible(int a)
		{
			if (a == 1)
			{
				Panel1.Visible = true;
				Label10.Visible = true;
				lblConsigneeCD.Visible = true;
				lblBPOCode.Visible = true;
				ddlConsigneeCD.Visible = true;
				ddlBPOCode.Visible = true;
				btnSaveCB.Visible = true;
				//btnDelCB.Visible=true;
				grdCB.Visible = true;
				lblFirm.Visible = true;
				Label11.Visible = true;

				//fillgrid();


			}
			else
			{
				Panel1.Visible = false;
				Label10.Visible = false;
				lblConsigneeCD.Visible = false;
				lblBPOCode.Visible = false;
				ddlConsigneeCD.Visible = false;
				ddlBPOCode.Visible = false;
				btnSaveCB.Visible = false;
				btnDelCB.Visible = false;
				grdCB.Visible = false;
				lblFirm.Visible = false;
				Label11.Visible = false;




			}

		}

		void fillgrid()
		{
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "SELECT P.CASE_NO,P.CONSIGNEE_CD,P.BPO_CD,(C.CONSIGNEE_CD||'-'||nvl2(trim(C.CONSIGNEE_DESIG),trim(C.CONSIGNEE_DESIG)||'/','')||nvl2(trim(C.CONSIGNEE_DEPT),trim(C.CONSIGNEE_DEPT)||'/','')||nvl2(trim(C.CONSIGNEE_FIRM),trim(C.CONSIGNEE_FIRM)||'/','')||NVL2(trim(C.CONSIGNEE_ADD1),trim(C.CONSIGNEE_ADD1)||'/','')||NVL2(trim(D.LOCATION),trim(D.LOCATION)||' : '||trim(D.CITY),trim(D.CITY))) CONSIGNEE_NAME,(B.BPO_CD||' - '||B.BPO_NAME||'/'||B.BPO_RLY||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(E.LOCATION,E.CITY||'/'||E.LOCATION,E.CITY)) BPO_NAME from T14_PO_BPO P, T06_CONSIGNEE C, T12_BILL_PAYING_OFFICER B,T03_CITY D ,T03_CITY E where P.CONSIGNEE_CD=C.CONSIGNEE_CD AND P.BPO_CD=B.BPO_CD AND C.CONSIGNEE_CITY=D.CITY_CD AND B.BPO_CITY_CD=E.CITY_CD AND CASE_NO='" + lblCasNo.Text + "'";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdCB.Visible = false;
				}
				else
				{
					grdCB.Visible = true;
					grdCB.DataSource = dsP;
					grdCB.DataBind();
					btnPODetails.Visible = true;
					Label10.Visible = true;
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

		// ------------------ Select Change Effects on Railway Non-Railway Field ------------------ //
		private void ddlRNR_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//			fill_consignee_purcher();
			//			if(ddlRNR.SelectedItem.Text=="Railway")
			//			{
			//				lblRailwayCode.Visible=true;
			//				ddlRCode.Visible=true;
			//				lblContNo.Visible=false;
			//				txtCNO.Visible=false;
			//				lblProjectRef.Visible=false;
			//				txtProjRef.Visible=false;
			//				lblContDate.Visible=false;
			//				txtConDate.Visible=false;
			//				lblMinFee.Visible=false;
			//				txtMinFee.Visible=false;
			//				lblMaxFee.Visible=false;
			//				txtMaxFee.Visible=false; 
			//				lblSvrToBeIncluded.Visible=false;
			//				ddlSrvTax.Visible=false;
			//			}	
			//			else 
			//			{
			//				visible();
			//			}	
		}

		private void btnSaveCB_Click(object sender, System.EventArgs e)
		{
			try
			{

				string cno = lblCasNo.Text;
				string str3 = "select CASE_NO from T14_PO_BPO where CASE_NO='" + cno + "' AND CONSIGNEE_CD=" + ddlConsigneeCD.SelectedValue;
				OracleCommand myInsertCommand = new OracleCommand();
				myInsertCommand.CommandText = str3;
				myInsertCommand.Connection = conn1;
				conn1.Open();
				string CD = Convert.ToString(myInsertCommand.ExecuteScalar());
				if (CD == "")
				{
					string myInsertQuery = "INSERT INTO T14_PO_BPO values('" + cno + "'," + ddlConsigneeCD.SelectedValue + ",'" + ddlBPOCode.SelectedValue + "')";
					myInsertCommand.CommandText = myInsertQuery;
					myInsertCommand.Connection = conn1;
					myInsertCommand.ExecuteNonQuery();
					conn1.Close();
				}
				else
				{
					ccd = Convert.ToInt32(Request.QueryString["CONSIGNEE_CD"]);
					bcd = Convert.ToString(Request.QueryString["BPO_CD"]);
					OracleCommand myUpdateCommand = new OracleCommand();
					string myUpdateQuery = "Update T14_PO_BPO set CONSIGNEE_CD =" + ddlConsigneeCD.SelectedValue + ", BPO_CD ='" + ddlBPOCode.SelectedValue + "' where CASE_NO='" + cno + "' AND CONSIGNEE_CD=" + ccd + " AND BPO_CD='" + bcd + "'";
					myUpdateCommand.CommandText = myUpdateQuery;
					myUpdateCommand.Connection = conn1;
					myUpdateCommand.ExecuteNonQuery();
					conn1.Close();
					ddlConsigneeCD.Enabled = true;
				}
				fillgrid();
				btnSaveCB.Text = "Add Consignee:BPO";
				fill_ConsigneeCd();
				txtSCon.Visible = true;
				txtSCon.Text = "";
				txtSBPO.Text = "";
				btnSCon.Visible = true;
				Label15.Visible = true;
				fill_BPOcd();
				btnDelCB.Visible = false;

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

		private void btnDelCB_Click(object sender, System.EventArgs e)
		{
			try
			{
				string cno = lblCasNo.Text;
				ccd = Convert.ToInt32(Request.QueryString["CONSIGNEE_CD"]);
				bcd = Convert.ToString(Request.QueryString["BPO_CD"]);
				String myDeleteQuery = "Delete T14_PO_BPO where CASE_NO='" + cno + "' AND CONSIGNEE_CD=" + ccd + " AND BPO_CD='" + bcd + "'";
				OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
				myOracleCommand.Connection = conn1;
				conn1.Open();
				myOracleCommand.ExecuteNonQuery();
				conn1.Close();
				btnDelCB.Visible = false;
				btnSaveCB.Text = "Add Consignee:BPO";
			}
			catch (OracleException ex)
			{
				string str;
				str = ex.Message;

				if (ex.ErrorCode == 02292)
				{
					string str1 = "You have already entered PO Details for the consignee you are deleting. To rectify this problem please insert the correct consignee& bpo details , then change the required entries in PO Details and save them. After doing this you can now delete the wrong entry for BPO-Consignee.";
					DisplayAlert(str1);
				}
				else
				{
					DisplayAlert(str);
				}

			}
			finally
			{
				conn1.Close();
			}
			fillgrid();
			fill_ConsigneeCd();
			txtSCon.Visible = true;
			btnSCon.Visible = true;
			txtSCon.Text = "";
			txtSBPO.Text = "";
			Label15.Visible = true;
			fill_BPOcd();
			ddlConsigneeCD.Enabled = true;
		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		private void btnFCList_Click(object sender, System.EventArgs e)
		{
			ddlVender.Visible = true;

			try
			{
				if (Convert.ToInt32(txtVend.Text) >= 1 && Convert.ToInt32(txtVend.Text) <= 999999)
				{

					string str1 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and trim(VEND_CD)=" + txtVend.Text.Trim() + " and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME";
					int a = fill_vendor(str1);
					if (a == 1)
					{
						ddlVender.Visible = false;
						DisplayAlert("No Vendor Found!!!");
						rbs.SetFocus(txtVend);
					}
					else if (a == 2)
					{
						vendor_status(ddlVender.SelectedValue);
						rbs.SetFocus(ddlVender);
					}
				}
				else
				{
					DisplayAlert("Invalid Vendor Code!!!");
					ddlVender.Items.Clear();
					ddlVender.Visible = false;
				}


			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = "Input string was not in a correct format.";
				if (str.Equals(str1))
				{
					string str2 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and trim(upper(VEND_NAME)) LIKE upper('" + txtVend.Text.Trim() + "%') and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME";
					int a = fill_vendor(str2);
					if (a == 1)
					{
						ddlVender.Visible = false;
						DisplayAlert("No Vendor Found!!!");
						rbs.SetFocus(txtVend);
					}
					else if (a == 2)
					{
						vendor_status(ddlVender.SelectedValue);
						rbs.SetFocus(ddlVender);

					}
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

		private void ddlVender_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
			vendor_status(ddlVender.SelectedValue);
			rbs.SetFocus(ddlPOLetter);

		}

		void vendor_status(String ven)
		{
			try
			{
				string vend;
				conn1.Open();
				string s = "select VEND_STATUS,to_char(VEND_STATUS_DT_FR,'dd/mm/yyyy')VEND_STATUS_FR,to_char(VEND_STATUS_DT_TO,'dd/mm/yyyy')VEND_STATUS_TO from T05_VENDOR where  VEND_CD='" + ddlVender.SelectedValue + "'";
				OracleCommand cmd = new OracleCommand(s, conn1);
				dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					vend = Convert.ToString(dr["VEND_STATUS"]);
					if (vend == "B")
					{
						DisplayAlert("This Vendor is Blaclisted From:" + Convert.ToString(dr["VEND_STATUS_FR"]) + " TO: " + Convert.ToString(dr["VEND_STATUS_TO"]));
						txtVend.Text = "";
						ddlVender.Visible = false;
					}
					else
					{
						txtVend.Text = ddlVender.SelectedValue;
					}
				}
				dr.Close();
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

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("PurchesOrder1_Form.aspx");
		}


		void repopulate_con_cd(string concd)
		{
			ddlConsigneeCD.Items.Clear();
			OracleDataReader reader;
			string str1 = "select A.CONSIGNEE_CD,(A.CONSIGNEE_CD||'-'||nvl2(trim(A.CONSIGNEE_DESIG),trim(A.CONSIGNEE_DESIG)||'/','')||nvl2(trim(A.CONSIGNEE_DEPT),trim(A.CONSIGNEE_DEPT)||'/','')||nvl2(trim(A.CONSIGNEE_FIRM),trim(A.CONSIGNEE_FIRM)||'/','')||NVL2(trim(A.CONSIGNEE_ADD1),trim(A.CONSIGNEE_ADD1)||'/','')||NVL2(trim(B.LOCATION),trim(B.LOCATION)||' : '||trim(B.CITY),trim(B.CITY))) CONSIGNEE_NAME from T06_CONSIGNEE A, T03_CITY B WHERE A.CONSIGNEE_CITY=B.CITY_CD and A.CONSIGNEE_CD='" + concd + "' ORDER BY CONSIGNEE_NAME";
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			ListItem lst;
			conn1.Open();
			reader = myOracleCommand.ExecuteReader();

			if (reader.HasRows == false)
			{
				DisplayAlert("Invalid Search Data");
			}
			else
			{
				while (reader.Read())
				{
					lst = new ListItem();
					lst.Text = reader["CONSIGNEE_NAME"].ToString();
					lst.Value = reader["CONSIGNEE_CD"].ToString();
					ddlConsigneeCD.Items.Add(lst);
				}
				ddlConsigneeCD.Visible = true;
				ddlConsigneeCD.SelectedIndex = 0;
				//rbs.SetFocus(ddlVender);


			}
			conn1.Close();

		}

		void repopulate_bpo_cd(string bcd)
		{
			ddlBPOCode.Items.Clear();
			OracleDataReader reader;
			//string str1 = "select BPO_CD,(BPO_NAME||'/'||BPO_RLY||'/'||BPO_ADD) BPO_NAME from T12_BILL_PAYING_OFFICER where BPO_CD='"+bcd+"' ORDER BY BPO_NAME"; 
			string str1 = "select BPO_CD,(B.BPO_CD||'-'||B.BPO_NAME||'/'||B.BPO_RLY||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)) BPO_NAME from T12_BILL_PAYING_OFFICER B, T03_CITY C where B.BPO_CITY_CD=C.CITY_CD and  B.BPO_CD='" + bcd + "' ORDER BY B.BPO_NAME";
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			ListItem lst;
			conn1.Open();
			reader = myOracleCommand.ExecuteReader();

			if (reader.HasRows == false)
			{
				DisplayAlert("Invalid Search Data");
			}
			else
			{
				while (reader.Read())
				{
					lst = new ListItem();
					lst.Text = reader["BPO_NAME"].ToString();
					lst.Value = reader["BPO_CD"].ToString();
					ddlBPOCode.Items.Add(lst);
				}
				ddlBPOCode.Visible = true;
				ddlBPOCode.SelectedIndex = 0;
				//rbs.SetFocus(ddlVender);


			}
			conn1.Close();

		}

		void repopulate_pur_cd(string pcd)
		{
			if (pcd.CompareTo("") != 0)
			{
				ddlPurcherCode.Items.Clear();
				OracleDataReader reader;
				string str1 = "select A.CONSIGNEE_CD,(A.CONSIGNEE_CD||'-'||nvl2(trim(CONSIGNEE_FIRM),trim(CONSIGNEE_FIRM)||'/','')||nvl2(trim(CONSIGNEE_DESIG),trim(CONSIGNEE_DESIG)||'/','')||nvl2(trim(CONSIGNEE_DEPT),trim(CONSIGNEE_DEPT)||'/','')||CITY)  CONSIGNEE_NAME from T06_CONSIGNEE A, T03_CITY B WHERE A.CONSIGNEE_CITY=B.CITY_CD and A.CONSIGNEE_CD='" + pcd + "' ORDER BY (nvl2(trim(CONSIGNEE_FIRM),trim(CONSIGNEE_FIRM)||'/','')||nvl2(trim(CONSIGNEE_DESIG),trim(CONSIGNEE_DESIG)||'/','')||nvl2(trim(CONSIGNEE_DEPT),trim(CONSIGNEE_DEPT)||'/','')||CITY)";
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				ListItem lst;
				conn1.Open();
				reader = myOracleCommand.ExecuteReader();

				if (reader.HasRows == false)
				{
					DisplayAlert("Invalid Search Data");
				}
				else
				{
					while (reader.Read())
					{
						lst = new ListItem();
						lst.Text = reader["CONSIGNEE_NAME"].ToString();
						lst.Value = reader["CONSIGNEE_CD"].ToString();
						ddlPurcherCode.Items.Add(lst);
					}
					ddlPurcherCode.Visible = true;
					ddlPurcherCode.SelectedIndex = 0;
					//rbs.SetFocus(ddlVender);


				}
				conn1.Close();
			}

		}

		private void btnSCon_Click(object sender, System.EventArgs e)
		{
			ddlConsigneeCD.Items.Clear();
			DataSet dsP = new DataSet();
			string str1 = "Select CONSIGNEE_CD, (CONSIGNEE_CD||'-'||CONSIGNEE)CONSIGNEE from V06_CONSIGNEE where upper(trim(CONSIGNEE)) like trim(upper('" + txtSCon.Text.Trim() + "%')) order by V06_CONSIGNEE.CONSIGNEE";
			OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			ListItem lst;
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			if (dsP.Tables[0].Rows.Count == 0)
			{
				DisplayAlert("Invalid Search Data");
				//ddlConsigneeCD.Visible=false;
			}
			else
			{
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					lst = new ListItem();
					lst.Text = dsP.Tables[0].Rows[i]["CONSIGNEE"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["CONSIGNEE_CD"].ToString();
					ddlConsigneeCD.Items.Add(lst);
				}
				ddlConsigneeCD.Visible = true;
				ddlConsigneeCD.SelectedIndex = 0;
				//rbs.SetFocus(ddlVender);


			}

		}

		private void btnSBPO_Click(object sender, System.EventArgs e)
		{
			ddlBPOCode.Items.Clear();
			DataSet dsP = new DataSet();
			string str1 = "Select BPO_CD, (BPO_CD||'-'||BPO) BPO from V12_BILL_PAYING_OFFICER where upper(trim(BPO)) like trim(upper('" + txtSBPO.Text.Trim() + "%')) order by V12_BILL_PAYING_OFFICER.BPO";
			OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			ListItem lst;
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			if (dsP.Tables[0].Rows.Count == 0)
			{
				DisplayAlert("Invalid Search Data");
				//ddlBPOCode.Visible=false;
			}
			else
			{
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					lst = new ListItem();
					lst.Text = dsP.Tables[0].Rows[i]["BPO"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["BPO_CD"].ToString();
					ddlBPOCode.Items.Add(lst);
				}
				ddlBPOCode.Visible = true;
				ddlBPOCode.SelectedIndex = 0;
				//rbs.SetFocus(ddlVender);


			}
		}

		private void btnSPur_Click(object sender, System.EventArgs e)
		{
			ddlPurcherCode.Items.Clear();
			DataSet dsP = new DataSet();
			string str1 = "select CONSIGNEE_CD,(CONSIGNEE_CD||'-'||CONSIGNEE) CONSIGNEE from V06_CONSIGNEE where upper(trim(CONSIGNEE)) like upper(trim('" + txtSPur.Text + "%')) ORDER BY V06_CONSIGNEE.CONSIGNEE";
			OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			ListItem lst;
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			if (dsP.Tables[0].Rows.Count == 0)
			{
				DisplayAlert("Invalid Search Data");
			}
			else
			{
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					lst = new ListItem();
					lst.Text = dsP.Tables[0].Rows[i]["CONSIGNEE"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["CONSIGNEE_CD"].ToString();
					ddlPurcherCode.Items.Add(lst);
				}
				ddlPurcherCode.Visible = true;
				ddlPurcherCode.SelectedIndex = 0;
				//rbs.SetFocus(ddlVender);


			}

		}


	}
}