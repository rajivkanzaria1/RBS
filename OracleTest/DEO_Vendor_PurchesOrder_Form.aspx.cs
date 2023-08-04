using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.DEO_Vendor_PurchesOrder_Form
{
	public partial class DEO_Vendor_PurchesOrder_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		OracleDataReader dr;

		static string caseno;
		string ss, ptype, rtype, bcd;
		int ccd;
		protected System.Web.UI.WebControls.Label lblRemarks;
		int ecode = 0;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnFCList.Attributes.Add("OnClick", "JavaScript:validate1();");
			btnSPur.Attributes.Add("OnClick", "JavaScript:validate3(txtSPur);");


			if (!IsPostBack)
			{
				if (Convert.ToString(Request.QueryString["case_no"]) == null || Convert.ToString(Request.QueryString["case_no"]) == "")
				{
					//fill_Rly();
					//fill_vendor();
					fill_Region(Session["Region"].ToString());
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

					if (Request.QueryString["CONSIGNEE_CD"] != null)
					{

						ccd = Convert.ToInt32(Request.QueryString["CONSIGNEE_CD"]);
						bcd = Convert.ToString(Request.QueryString["BPO_CD"]);


					}


					//fill_Region(Session["Region"].ToString());
					//po_type();

					if (action == "M")
					{

						//btnPODetails.Visible=true;
						txtPOdate.Enabled = false;
						//txtDatePOrites.Enabled=false;

					}
					else if (action == "D")
					{

						//btnPODetails.Visible=false;
					}
					else
					{
						txtPOdate.Enabled = false;
					}

					if (Session["Role_CD"].ToString() == "4")
					{

						btnPODetails.Visible = true;
						txtPOdate.Enabled = false;
						btnFCList.Visible = false;
						btnSPur.Visible = false;

						//txtDatePOrites.Enabled=false;
					}

				}
			}
			//ddlRegionCode.SelectedValue=Session["Region"].ToString();
			lblCasNo.Text = Request.QueryString["case_no"].ToString();
			lblCasNo.Visible = true;

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
				string str3 = "Select lpad(nvl(max(to_number(nvl(substr(CASE_NO,6,4),0))),0)+1,4,'0') from T80_PO_MASTER where REGION_CODE ='" + region + "' and substr(CASE_NO,1,5)='" + ffive + "'";
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
				string str1 = "select CASE_NO,PURCHASER_CD,PURCHASER,STOCK_NONSTOCK,PO_OR_LETTER,RLY_NONRLY,PO_NO,to_char(PO_DT,'dd/mm/yyyy')PO_DT,to_char(RECV_DT,'dd/mm/yyyy')RECV_DT,VEND_CD,NVL(RLY_CD,'0') RLY_CD,RLY_CD_DESC,REGION_CODE,REMARKS,POI_CD from T80_PO_MASTER where CASE_NO='" + lblCasNo.Text + "'";
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

				//					ddlInspAgency.SelectedValue=Convert.ToString(reader.Tables[0].Rows[0]["INSPECTING_AGENCY"]);

				if (Convert.ToString(reader.Tables[0].Rows[0]["RLY_CD"]) == "0")
				{
					lstBPO_Rly.SelectedValue = "0";
					txtBPO_RLY.Text = Convert.ToString(reader.Tables[0].Rows[0]["RLY_CD_DESC"]);
				}
				else
				{
					lstBPO_Rly.SelectedValue = Convert.ToString(reader.Tables[0].Rows[0]["RLY_CD"]);
				}
				if (Convert.ToString(reader.Tables[0].Rows[0]["RLY_NONRLY"]) == "R")
				{

					//lblRailwayCode.Visible=true;
					//ddlRCode.Visible=true;
					//ddlRCode.SelectedValue = Convert.ToString(reader["RLY_CD"]);

					lblRailwayCode.Text = Convert.ToString(reader.Tables[0].Rows[0]["RLY_NONRLY"]);
					if (Convert.ToString(reader.Tables[0].Rows[0]["RLY_CD"]) == "0")
					{
						lblRCD.Text = Convert.ToString(reader.Tables[0].Rows[0]["RLY_CD_DESC"]);
					}
					else
					{
						lblRCD.Text = Convert.ToString(reader.Tables[0].Rows[0]["RLY_CD"]);
						txtBPO_RLY.Visible = false;
					}
					conn1.Close();
					po_type(lblRailwayCode.Text, lblRCD.Text);
					//po_type(Convert.ToString(reader.Tables[0].Rows[0]["RLY_CD"]));
					//lblFirm.Text=ddlRCode.SelectedItem.Text;
					//lblFirmCD.Text=ddlRCode.SelectedValue;

					//Label8.Visible=true;
					//ddlRNR.Visible=false;
					//Label8.Text="Railway";
				}
				else if (Convert.ToString(reader.Tables[0].Rows[0]["RLY_NONRLY"]) != "R")
				{
					//						visible();

					//Label8.Visible=false;
					//ddlRNR.Visible=true;
					lblRailwayCode.Text = Convert.ToString(reader.Tables[0].Rows[0]["RLY_NONRLY"]);
					if (Convert.ToString(reader.Tables[0].Rows[0]["RLY_CD"]) == "0")
					{
						lblRCD.Text = Convert.ToString(reader.Tables[0].Rows[0]["RLY_CD_DESC"]);
					}
					else
					{
						lblRCD.Text = Convert.ToString(reader.Tables[0].Rows[0]["RLY_CD"]);
					}
					po_type(lblRailwayCode.Text, lblRCD.Text);
					//po_type(Convert.ToString(reader.Tables[0].Rows[0]["RLY_NONRLY"]));
					//ddlRNR.SelectedValue = Convert.ToString(reader["RLY_NONRLY"]);
					//lblFirm.Text=ddlRNR.SelectedItem.Text;
					//lblFirmCD.Text=ddlRNR.SelectedValue;

					//						OracleCommand cmd1=new OracleCommand("select CONTRACT_NO,TO_CHAR(CONTRACT_DT,'dd/mm/yyyy')CONTRACT_DT,PROJECT_REF,MIN_FEE,MAX_FEE,WITH_SERV_TAX from T14A_PO_NONRLY where CASE_NO='" + lblCasNo.Text + "'",conn1); 
					//						conn1.Open();
					//						OracleDataReader reader1 = cmd1.ExecuteReader();
					//						while(reader1.Read())
					//						{
					//							txtCNO.Text = Convert.ToString(reader1["CONTRACT_NO"]);
					//							txtConDate.Text = Convert.ToString(reader1["CONTRACT_DT"]);
					//							txtProjRef.Text = Convert.ToString(reader1["PROJECT_REF"]);
					//							txtMinFee.Text = Convert.ToString(reader1["MIN_FEE"]);
					//							txtMaxFee.Text = Convert.ToString(reader1["MAX_FEE"]);
					//							ddlSrvTax.SelectedValue=Convert.ToString(reader1["WITH_SERV_TAX"]);
					//						}
					//						conn1.Close();
				}
				fill_Rly();
				lstBPO_Rly.SelectedValue = reader.Tables[0].Rows[0]["RLY_CD"].ToString();
				//				lblRCD.Text=lstBPO_Rly.SelectedValue;
				//				lblRailway.Text=lstBPO_Rly.SelectedItem.Text;
				//				txtSPur.Text=lblRCD.Text;
				//				purchaser_click();
				repopulate_pur_cd(Convert.ToString(reader.Tables[0].Rows[0]["PURCHASER_CD"]));
				if (Convert.ToString(reader.Tables[0].Rows[0]["PURCHASER_CD"]) != "0")
				{
					ddlPurcherCode.SelectedValue = Convert.ToString(reader.Tables[0].Rows[0]["PURCHASER_CD"]);
					txtPurchaser.Visible = false;

				}
				else
				{
					ddlPurcherCode.SelectedValue = "0";
					txtSPur.Text = "";
					txtPurchaser.Text = Convert.ToString(reader.Tables[0].Rows[0]["PURCHASER"]);
				}
				txtPON.Text = Convert.ToString(reader.Tables[0].Rows[0]["PO_NO"]);
				//					txtPOLst5.Text = Convert.ToString(reader.Tables[0].Rows[0]["L5NO_PO"]);
				txtPOdate.Text = Convert.ToString(reader.Tables[0].Rows[0]["PO_DT"]);
				txtPORemarks.Text = Convert.ToString(reader.Tables[0].Rows[0]["REMARKS"]);
				lblPORemarks.Text = Convert.ToString(reader.Tables[0].Rows[0]["REMARKS"]);
				txtDatePOrites.Text = Convert.ToString(reader.Tables[0].Rows[0]["RECV_DT"]);
				string str2 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and trim(VEND_CD)=" + Convert.ToString(reader.Tables[0].Rows[0]["VEND_CD"]) + " and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME";
				fill_vendor(str2);
				ddlVender.SelectedValue = Convert.ToString(reader.Tables[0].Rows[0]["VEND_CD"]);
				txtVend.Text = Convert.ToString(reader.Tables[0].Rows[0]["VEND_CD"]);
				//vendor_status(ddlVender.SelectedValue);

				txtMName.Text = reader.Tables[0].Rows[0]["POI_CD"].ToString();
				if (txtMName.Text.Trim() != "")
				{
					string str3 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and trim(VEND_CD)=" + txtMName.Text.Trim() + " and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME";
					int a = fill_manufacturer(str3);
					if (a == 1)
					{
						ddlManufac.Visible = false;
						txtMPOI.Text = "";
						DisplayAlert("No Manufacturer Found!!!");
						rbs.SetFocus(txtMPOI);
					}
					else if (a == 2)
					{
						txtMName.Text = ddlManufac.SelectedValue;
						manufac_details();
						rbs.SetFocus(ddlManufac);

					}
				}
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
		int fill_manufacturer(string str1)
		{
			ddlManufac.Items.Clear();
			DataSet dsP = new DataSet();
			//string str1 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME,VEND_ADD1,VEND_CONTACT_PER_1,VEND_CONTACT_TEL_1 from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and (trim(upper(VEND_CD))=upper('"+vend.Trim()+"') or trim(upper(VEND_NAME)) LIKE upper('"+vend.Trim()+"%')) and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME"; 
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
					ddlManufac.Items.Add(lst);
				}
				ddlManufac.Visible = true;
				ddlManufac.SelectedIndex = 0;
				//rbs.SetFocus(ddlManufac);
				ecode = 2;
				return (ecode);

			}

		}

		void manufac_details()
		{

			OracleCommand cmd = new OracleCommand("select VEND_ADD1,VEND_CONTACT_PER_1,VEND_CONTACT_TEL_1,VEND_STATUS,to_char(VEND_STATUS_DT_FR,'dd/mm/yyyy')VEND_STATUS_FR,to_char(VEND_STATUS_DT_TO,'dd/mm/yyyy')VEND_STATUS_TO,VEND_EMAIL from T05_VENDOR where VEND_CD=" + ddlManufac.SelectedValue, conn1);
			conn1.Open();
			OracleDataReader reader = cmd.ExecuteReader();
			if (reader.HasRows == true)
			{
				while (reader.Read())
				{
					if (Convert.ToString(reader["VEND_STATUS"]) == "B")
					{
						DisplayAlert("It is informed that due to unavoidable reasons, online call booking facility has temporarily restricted against your ID From: " + Convert.ToString(reader["VEND_STATUS_FR"]) + ". ");
						txtMName.Text = "";
						ddlManufac.Visible = false;
						txtMPOI.Text = "";

					}
					else
					{
						txtMPOI.Text = Convert.ToString(reader["VEND_ADD1"]);
						txtMPOI.Enabled = false;
					}

				}
			}
			else
			{
				txtMPOI.Text = "";

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

		void purchaser_click()
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
				lst = new ListItem();
				lst.Text = "Other";
				lst.Value = "0";
				ddlPurcherCode.Items.Insert(0, lst);
			}
			else
			{
				int i = 0;
				for (i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					lst = new ListItem();
					lst.Text = dsP.Tables[0].Rows[i]["CONSIGNEE"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["CONSIGNEE_CD"].ToString();
					ddlPurcherCode.Items.Add(lst);
				}
				lst = new ListItem();
				lst.Text = "Other";
				lst.Value = "0";
				ddlPurcherCode.Items.Insert(i, lst);
				ddlPurcherCode.Visible = true;
				ddlPurcherCode.SelectedIndex = 0;
				//rbs.SetFocus(ddlVender);


			}
		}
		public void fill_Rly()
		{
			lstBPO_Rly.Items.Clear();
			DataSet dsP = new DataSet();
			string str = "";
			if (lblRailwayCode.Text == "R")
			{
				str = "Select RLY_CD,RAILWAY from T91_RAILWAYS where RLY_CD<>'CORE' Order by RLY_CD";
			}
			else
			{
				str = "Select distinct(upper(trim(BPO_RLY))) RLY_CD, BPO_ORGN RAILWAY from T12_BILL_PAYING_OFFICER WHERE BPO_TYPE='" + lblRailwayCode.Text + "' Order by RLY_CD";
			}
			OracleDataAdapter da = new OracleDataAdapter(str, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str, conn1);
			ListItem lst;
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			conn1.Close();
			int i = 0;
			for (i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
			{
				lst = new ListItem();
				lst.Text = dsP.Tables[0].Rows[i]["RAILWAY"].ToString();
				lst.Value = dsP.Tables[0].Rows[i]["RLY_CD"].ToString();
				lstBPO_Rly.Items.Add(lst);
			}
			lst = new ListItem();
			lst.Text = "Other";
			lst.Value = "0";
			lstBPO_Rly.Items.Insert(i, lst);
			//			lblRCD.Text=lstBPO_Rly.SelectedValue;
			//			lblRailway.Text=lstBPO_Rly.SelectedItem.Text;


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
				//				visible();

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
				if (rcd == "")
				{
					lblRailway.Text = "Other";
				}
				else
				{
					lblRailway.Text = " (" + rcd + ")";
				}
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


		protected void btnPODetails_Click(object sender, System.EventArgs e)
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
			Response.Redirect("DEO_Vendor_PurchesOrderDetails.aspx?CASE_NO=" + caseno + "&type=" + pt + "&PODT=" + txtPOdate.Text.Trim() + "&PO_OR_LOA=" + ddlPOLetter.SelectedValue);
		}
		// ------------------ Clearing Fields ------------------ //
		public void clear()
		{
			lblCasNo.Text = "";
			txtPON.Text = "";
			txtPOLst5.Text = "";
			txtPOdate.Text = "";
			txtDatePOrites.Text = "";

			fill_consignee_purcher();
			//fill_Region();
		}






		// ------------------ Select Change Effects on Railway Non-Railway Field ------------------ //
		private void ddlRNR_SelectedIndexChanged(object sender, System.EventArgs e)
		{

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
						DisplayAlert("This Vendor is Banned/Blacklisted From  " + Convert.ToString(dr["VEND_STATUS_FR"]) + " To " + Convert.ToString(dr["VEND_STATUS_TO"]));
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

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("DEO_Vendor_PurchesOrder1_Form.aspx");
		}


		protected void btnSPur_Click(object sender, System.EventArgs e)
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

		protected void btnAcceptPO_Click(object sender, System.EventArgs e)
		{
			conn1.Open();
			OracleCommand cmd = null;
			int err_code = 0;
			try
			{
				cmd = new OracleCommand("GENERATE_REAL_CASE_NO", conn1);
				cmd.CommandType = CommandType.StoredProcedure;

				OracleParameter prm1 = new OracleParameter("IN_REGION_CD", OracleDbType.Char);
				prm1.Direction = ParameterDirection.Input;
				prm1.Value = Session["REGION"];
				cmd.Parameters.Add(prm1);

				OracleParameter prm2 = new OracleParameter("IN_TEMP_CASE_NO", OracleDbType.Varchar2);
				prm2.Direction = ParameterDirection.Input;
				prm2.Value = Convert.ToString(lblCasNo.Text);
				cmd.Parameters.Add(prm2);

				OracleParameter prm3 = new OracleParameter("IN_TEMP_USER_ID", OracleDbType.Varchar2);
				prm3.Direction = ParameterDirection.Input;
				prm3.Value = Convert.ToString(Session["Uname"].ToString());
				cmd.Parameters.Add(prm3);

				OracleParameter prm4 = new OracleParameter("OUT_CASE_NO", OracleDbType.Char, 9);
				prm4.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(prm4);

				OracleParameter prm5 = new OracleParameter("OUT_ERR_CD", OracleDbType.Int32, 1);
				prm5.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(prm5);

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

			err_code = Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value);
			if (err_code == 1)
			{
				DisplayAlert("No Purchase Order Registered by the Vendor.");
			}
			else if (err_code == 2)
			{
				DisplayAlert("Either Agent/Client or Purchaser is Missing. The value [Others] is not acceptable for Agent/Client or Purchaser");
			}
			else if (err_code == 3)
			{
				DisplayAlert("Either Consignee or BPO is Missing in Item Details. The value [Others] is not acceptable in Consignee/BPO.");
			}
			else if (err_code == 4)
			{
				DisplayAlert("Unable to Insert data in PO Master (T13). Contact System Administrator.");
			}
			else if (err_code == 5)
			{
				DisplayAlert("Unable to Insert data in PO-BPO Master (T14). Contact System Administrator.");
			}
			else if (err_code == 6)
			{
				DisplayAlert("Unable to Insert data in PO Details (T15). Contact System Administrator.");
			}
			else if (err_code == 7)
			{
				DisplayAlert("Unable to Update Case No. in T80. Contact System Administrator.");
			}
			else
			{
				lblRealCaseNO1.Text = Convert.ToString(cmd.Parameters["OUT_CASE_NO"].Value);
				lblRealCaseNO.Text = " Case No. --> " + Convert.ToString(cmd.Parameters["OUT_CASE_NO"].Value);
				send_Vendor_Email();
				btnAcceptPO.Enabled = false;
				btnSave.Enabled = false;
				btnPODetails.Enabled = false;
				DisplayAlert("Case No. --> " + lblRealCaseNO1.Text);
				try
				{
					File.Copy(Server.MapPath("..") + @"/RBS/Vendor/PO/" + lblCasNo.Text + ".PDF", Server.MapPath("..") + @"/RBS/CASE_NO/" + lblRealCaseNO1.Text + ".PDF");
					DisplayAlert("File Copied!!!");
					//DisplayAlert(Server.MapPath(".."));

				}
				catch (Exception ex)
				{
					string str;
					str = ex.Message;
					DisplayAlert(Server.MapPath("..") + " & " + str);
				}

			}

		}

		protected void lstBPO_Rly_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lblRCD.Text = lstBPO_Rly.SelectedValue;
			lblRailway.Text = lstBPO_Rly.SelectedItem.Text;
			ptype = lblRailway.Text;
			lblRCD.Text = lstBPO_Rly.SelectedValue;
			if (lstBPO_Rly.SelectedValue == "0")
			{
				txtBPO_RLY.Visible = true;
				lstBPO_Rly.Visible = false;
				txtSPur.Visible = false;
				btnSPur.Visible = false;
				txtPurchaser.Visible = true;

			}
			else
			{
				txtBPO_RLY.Visible = false;
				lstBPO_Rly.Visible = true;
				txtSPur.Visible = true;
				btnSPur.Visible = true;
				txtPurchaser.Visible = false;
				if (ptype == "R")
				{
					rtype = lstBPO_Rly.SelectedValue;
					po_type(ptype, rtype);
				}
				else
				{
					rtype = lstBPO_Rly.SelectedValue;
					po_type(ptype, rtype);
				}


			}
			fill_consignee_purcher();
		}

		// ------------------ Button Save Function ------------------ //
		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			conn1.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
			ss = Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();
			update();
			btnPODetails.Visible = true;
			if (txtPORemarks.Text.Trim() != lblPORemarks.Text.Trim() && txtPORemarks.Text.Trim() != "")
			{
				send_vendor_remarks_email();
			}


		}
		//------------------- sending email to IE ------------------------//
		void send_vendor_remarks_email()
		{
			try
			{
				string wRegion = "";
				if (Session["Region"].ToString() == "N") { wRegion = "NORTHERN REGION \n 12th FLOOR,CORE-II,SCOPE MINAR,LAXMI NAGAR, DELHI - 110092 \n Phone : +918800018691-95 \n Fax : 011-22024665"; }
				else if (Session["Region"].ToString() == "S") { wRegion = "SOUTHERN REGION \n CTS BUILDING - 2ND FLOOR, BSNL COMPLEX, NO. 16, GREAMS ROAD,  CHENNAI - 600 006 \n Phone : 044-28292817 \n Fax : 044-28290359"; }
				else if (Session["Region"].ToString() == "E") { wRegion = "EASTERN REGION \n CENTRAL STATION BUILDING(METRO), 56, C.R. AVENUE,3rd FLOOR,KOLKATA-700 012  \n Fax : 033-22348704"; }
				else if (Session["Region"].ToString() == "W") { wRegion = "WESTERN REGION \n 5TH FLOOR, REGENT CHAMBER, ABOVE STATUS RESTAURANT,NARIMAN POINT,MUMBAI-400021 \n Phone : 022-68943400/68943445"; }
				else if (Session["Region"].ToString() == "C") { wRegion = "Central Region"; }

				OracleCommand cmd_vend = new OracleCommand("Select T13.VEND_CD,T05.VEND_NAME,NVL2(T05.VEND_ADD2,T05.VEND_ADD1||'/'||T05.VEND_ADD2,T05.VEND_ADD1)||'/'||T03.CITY VEND_ADDRESS, T05.VEND_EMAIL from T13_PO_MASTER T13,T05_VENDOR T05, T03_CITY T03 where T13.VEND_CD=T05.VEND_CD and T05.VEND_CITY_CD=T03.CITY_CD and CASE_NO='" + lblRealCaseNO1.Text.Trim() + "'", conn1);
				conn1.Open();
				OracleDataReader reader = cmd_vend.ExecuteReader();
				string vend_cd = "", vend_add = "", vend_email = "";
				while (reader.Read())
				{
					vend_cd = Convert.ToString(reader["VEND_CD"]);
					vend_add = Convert.ToString(reader["VEND_ADDRESS"]);
					vend_email = Convert.ToString(reader["VEND_EMAIL"]);

				}
				conn1.Close();

				OracleCommand cmd = new OracleCommand("Select VEND_EMAIL from T05_VENDOR where VEND_CD=" + ddlVender.SelectedValue, conn1);
				conn1.Open();
				string vend_mail = Convert.ToString(cmd.ExecuteScalar());
				conn1.Close();


				string mail_body = "Dear Sir/Madam,\n\n In Reference to your PO: No. " + txtPON.Text + " dated.  " + txtPOdate.Text + ", the Case No. is not allotted due to following Reasons: -  " + txtPORemarks.Text + ". Kindly update the Purchase order as per Reason mentioned and then delete the reason from the Remarks column and click on Save PO Button. Thanks for using RITES Inspection Services. \n NATIONAL INSPECTION HELP LINE NUMBER : 1800 425 7000 (TOLL FREE).\n\n" + wRegion + ".";
				string sender = "";
				if (Session["Region"].ToString() == "N")
				{
					sender = "nrinspn@rites.com";
				}
				else if (Session["Region"].ToString() == "W")
				{
					sender = "wrinspn@rites.com";
				}
				else if (Session["Region"].ToString() == "E")
				{
					sender = "erinspn@rites.com";
				}
				else if (Session["Region"].ToString() == "S")
				{
					sender = "srinspn@rites.com";
				}

				if (vend_mail != "")
				{
					MailMessage mail = new MailMessage();
					mail.To = vend_mail;
					mail.From = sender;
					mail.Subject = "Case No. not allocated against PO registered by you on our Portal.";
					mail.Body = mail_body;
					mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
					SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
					mail.Priority = MailPriority.High;
					SmtpMail.Send(mail);
				}
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
			}


		}

		void send_Vendor_Email()
		{
			try
			{
				string wRegion = "";
				if (Session["Region"].ToString() == "N") { wRegion = "NORTHERN REGION \n 12th FLOOR,CORE-II,SCOPE MINAR,LAXMI NAGAR, DELHI - 110092 \n Phone : +918800018691-95 \n Fax : 011-22024665"; }
				else if (Session["Region"].ToString() == "S") { wRegion = "SOUTHERN REGION \n CTS BUILDING - 2ND FLOOR, BSNL COMPLEX, NO. 16, GREAMS ROAD,  CHENNAI - 600 006 \n Phone : 044-28292817 \n Fax : 044-28290359"; }
				else if (Session["Region"].ToString() == "E") { wRegion = "EASTERN REGION \n CENTRAL STATION BUILDING(METRO), 56, C.R. AVENUE,3rd FLOOR,KOLKATA-700 012  \n Fax : 033-22348704"; }
				else if (Session["Region"].ToString() == "W") { wRegion = "WESTERN REGION \n 5TH FLOOR, REGENT CHAMBER, ABOVE STATUS RESTAURANT,NARIMAN POINT,MUMBAI-400021 \n Phone : 022-68943400/68943445"; }
				else if (Session["Region"].ToString() == "C") { wRegion = "Central Region"; }

				OracleCommand cmd_vend = new OracleCommand("Select T13.VEND_CD,T05.VEND_NAME,NVL2(T05.VEND_ADD2,T05.VEND_ADD1||'/'||T05.VEND_ADD2,T05.VEND_ADD1)||'/'||T03.CITY VEND_ADDRESS, T05.VEND_EMAIL from T13_PO_MASTER T13,T05_VENDOR T05, T03_CITY T03 where T13.VEND_CD=T05.VEND_CD and T05.VEND_CITY_CD=T03.CITY_CD and CASE_NO='" + lblRealCaseNO1.Text.Trim() + "'", conn1);
				conn1.Open();
				OracleDataReader reader = cmd_vend.ExecuteReader();
				string vend_cd = "", vend_add = "", vend_email = "";
				while (reader.Read())
				{
					vend_cd = Convert.ToString(reader["VEND_CD"]);
					vend_add = Convert.ToString(reader["VEND_ADDRESS"]);
					vend_email = Convert.ToString(reader["VEND_EMAIL"]);

				}
				conn1.Close();

				OracleCommand cmd = new OracleCommand("Select VEND_EMAIL from T05_VENDOR where VEND_CD=" + ddlVender.SelectedValue, conn1);
				conn1.Open();
				string vend_mail = Convert.ToString(cmd.ExecuteScalar());
				conn1.Close();


				string mail_body = "Dear Sir/Madam,\n\n In Reference to your PO: No. " + txtPON.Text + " dated.  " + txtPOdate.Text + " the Case No. alloted is  -  " + lblRealCaseNO1.Text + ". Kindly mention this Case No. while placing call on RITES. Thanks for using RITES Inspection Services. \n\n" + wRegion + ". \n NATIONAL INSPECTION HELP LINE NUMBER : 1800 425 7000 (TOLL FREE)";
				string sender = "";
				if (Session["Region"].ToString() == "N")
				{
					sender = "nrinspn@rites.com";
				}
				else if (Session["Region"].ToString() == "W")
				{
					sender = "wrinspn@rites.com";
				}
				else if (Session["Region"].ToString() == "E")
				{
					sender = "erinspn@rites.com";
				}
				else if (Session["Region"].ToString() == "S")
				{
					sender = "srinspn@rites.com";
				}

				if (vend_mail != "")
				{
					MailMessage mail = new MailMessage();
					mail.To = vend_mail;
					mail.From = sender;
					mail.Subject = "Case No. allocated against PO registered by you on our Portal.";
					mail.Body = mail_body;
					mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
					SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
					mail.Priority = MailPriority.High;
					SmtpMail.Send(mail);
				}
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
			}


		}

		// ------------------ Updating Record in Tables ------------------ //

		public void update()
		{

			try
			{
				if (lstBPO_Rly.SelectedValue != "0" && (ddlPurcherCode.SelectedValue != "0" && ddlPurcherCode.SelectedValue != ""))
				{
					conn1.Open();
					if (Label8.Text == "Railways")
					{
						OracleCommand cmd4 = new OracleCommand("update T80_PO_MASTER set STOCK_NONSTOCK = '" + ddlSNS.SelectedItem.Value + "',PO_OR_LETTER = '" + ddlPOLetter.SelectedItem.Value + "', PO_NO = '" + txtPON.Text.Trim() + "',RECV_DT=to_date('" + txtDatePOrites.Text + "','dd/mm/yyyy'),PURCHASER_CD='" + ddlPurcherCode.SelectedValue + "',RLY_CD = '" + lstBPO_Rly.SelectedItem.Value + "',REMARKS='" + txtPORemarks.Text.Trim() + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),POI_CD='" + txtMName.Text + "' where CASE_NO = '" + lblCasNo.Text + "'", conn1);
						cmd4.ExecuteNonQuery();
						caseno = lblCasNo.Text;
						DisplayAlert("Your Record Has Been Updated!!!");
					}
					else if (Label8.Text != "Railways")
					{
						casenofalse();
						OracleCommand cmd5 = new OracleCommand("update T80_PO_MASTER set STOCK_NONSTOCK = '" + ddlSNS.SelectedItem.Value + "',PO_OR_LETTER = '" + ddlPOLetter.SelectedItem.Value + "', PO_NO = '" + txtPON.Text.Trim() + "',RECV_DT=to_date('" + txtDatePOrites.Text + "','dd/mm/yyyy'),PURCHASER_CD='" + ddlPurcherCode.SelectedValue + "',RLY_CD = '" + lstBPO_Rly.SelectedItem.Value + "',REMARKS='" + txtPORemarks.Text.Trim() + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),POI_CD='" + txtMName.Text + "' where CASE_NO = '" + lblCasNo.Text + "'", conn1);
						cmd5.ExecuteNonQuery();
						caseno = lblCasNo.Text;
						DisplayAlert("Your Record Has Been Updated!!!");
					}
				}
				else
				{
					DisplayAlert("Select Client and Purchaser Before Saving The PO!!!");
				}


			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("../Error_Form.aspx?err=" + str1));
			}
			finally
			{
				conn1.Close();
			}

			conn1.Close();
			btnSave.Visible = true;
			lblCaseNo.Visible = true;
			lblCasNo.Visible = true;
			lblCasNo.Text = caseno;

		}

		protected void chkManuf_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chkManuf.Checked == true)
			{
				try
				{
					OracleCommand cmd = new OracleCommand("select VEND_CD,VEND_NAME,VEND_ADD1,VEND_CONTACT_PER_1,VEND_CONTACT_TEL_1,VEND_STATUS,to_char(VEND_STATUS_DT_FR,'dd/mm/yyyy')VEND_STATUS_FR,to_char(VEND_STATUS_DT_TO,'dd/mm/yyyy')VEND_STATUS_TO,VEND_EMAIL from T05_VENDOR where VEND_CD=" + ddlVender.SelectedValue, conn1);
					conn1.Open();
					OracleDataReader reader = cmd.ExecuteReader();
					if (reader.HasRows == true)
					{
						while (reader.Read())
						{
							if (Convert.ToString(reader["VEND_STATUS"]) == "B")
							{
								DisplayAlert("It is informed that due to unavoidable reasons, online call booking facility has temporarily restricted against your ID From: " + Convert.ToString(reader["VEND_STATUS_FR"]) + ". ");
								ddlManufac.Visible = false;


							}
							else
							{
								ddlManufac.Items.Clear();
								//								lst = new ListItem(); 
								//								lst.Text = reader["VEND_NAME"].ToString(); 
								//								lst.Value = reader["VEND_CD"].ToString(); 
								//								ddlManufac.Items.Add(lst); 
								txtMPOI.Text = Convert.ToString(reader["VEND_ADD1"]);
								//								txtMName.Text=reader["VEND_NAME"].ToString(); 

								ddlManufac.Visible = true;
								btnPOI.Visible = false;
								txtMPOI.Enabled = false;
								txtMName.Enabled = false;



							}




						}
						conn1.Close();
						string str1 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where V.VEND_CITY_CD=C.CITY_CD and VEND_CD=" + ddlVender.SelectedValue + " ORDER BY VEND_NAME";
						int a = fill_manufacturer(str1);
						if (a == 1)
						{
							ddlManufac.Visible = false;
							txtMPOI.Text = "";
							DisplayAlert("No Manufacturer Found!!!");
							rbs.SetFocus(txtMPOI);
						}
						else if (a == 2)
						{
							txtMName.Text = ddlManufac.SelectedValue;
							manufac_details();
							rbs.SetFocus(ddlManufac);

						}
					}
					else
					{

						btnPOI.Visible = true;
						txtMName.Enabled = true;
						txtMPOI.Text = "";

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
			else
			{

				txtMName.Enabled = true;
				txtMName.Text = "";
				ddlManufac.Items.Clear();
				ddlManufac.Visible = false;
				txtMPOI.Text = "";
				btnPOI.Visible = true;


			}
		}

		protected void btnPOI_Click(object sender, System.EventArgs e)
		{
			ddlManufac.Visible = true;
			ddlManufac.Enabled = true;
			try
			{
				if (Convert.ToInt32(txtMName.Text) >= 1 && Convert.ToInt32(txtMName.Text) <= 999999)
				{

					string str1 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and trim(VEND_CD)=" + txtMName.Text.Trim() + " and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME";
					int a = fill_manufacturer(str1);
					if (a == 1)
					{
						ddlManufac.Visible = false;
						txtMPOI.Text = "";
						DisplayAlert("No Manufacturer Found!!!");
						rbs.SetFocus(txtMPOI);
					}
					else if (a == 2)
					{
						txtMName.Text = ddlManufac.SelectedValue;
						manufac_details();
						rbs.SetFocus(ddlManufac);

					}
				}
				else
				{
					DisplayAlert("Invalid Manufacturer Code!!!");
					ddlManufac.Items.Clear();
					ddlManufac.Visible = false;
					txtMPOI.Text = "";



				}



			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = "Input string was not in a correct format.";
				if (str.Equals(str1))
				{
					string str2 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and trim(upper(VEND_NAME)) LIKE upper('" + txtMName.Text.Trim() + "%') and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME";
					int a = fill_manufacturer(str2);
					if (a == 1)
					{
						ddlManufac.Visible = false;
						txtMPOI.Text = "";
						DisplayAlert("No Manufacturer Found!!!");
						rbs.SetFocus(txtMPOI);
					}
					else if (a == 2)
					{
						txtMName.Text = ddlManufac.SelectedValue;
						manufac_details();
						rbs.SetFocus(ddlManufac);


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

		protected void ddlManufac_DataBinding(object sender, System.EventArgs e)
		{
		}

		protected void ddlManufac_SelectedIndexChanged(object sender, System.EventArgs e)
		{

			txtMName.Text = ddlManufac.SelectedValue;
			manufac_details();
			txtMPOI.Enabled = false;
		}



	}
}