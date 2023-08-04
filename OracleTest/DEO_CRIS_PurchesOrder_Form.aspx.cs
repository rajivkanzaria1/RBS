using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.DEO_CRIS_PurchesOrder_Form
{
	public partial class DEO_CRIS_PurchesOrder_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		OracleDataReader dr;

		static string caseno;
		string ss, rtype, bcd;
		int ccd;
		protected System.Web.UI.WebControls.Label lblRemarks;
		int ecode = 0;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnFCList.Attributes.Add("OnClick", "JavaScript:validate1();");
			btnSPur.Attributes.Add("OnClick", "JavaScript:validate3(txtSPur);");


			if (!IsPostBack)
			{

				if (Convert.ToString(Request.QueryString["IMMS_POKEY"]) != null || Convert.ToString(Request.QueryString["IMMS_POKEY"]) != "")
				{
					fill_Region(Session["Region"].ToString());
					lblRCD.Text = Convert.ToString(Request.QueryString["IMMS_RLY_CD"]);
					conn1.Open();
					OracleCommand cmd1 = new OracleCommand("Select nvl(RLY_CD,'XX') RLY_CD from T91_RAILWAYS WHERE IMMS_RLY_CD='" + lblRCD.Text + "'", conn1);
					rtype = Convert.ToString(cmd1.ExecuteScalar());
					conn1.Close();

					if (rtype == "XX" || rtype == "")
					{
						fill_Rly();
						txtBPO_RLY.Visible = true;
						txtBPO_RLY.Text = lblRCD.Text;
					}
					else
					{
						fill_Rly();
						lstBPO_Rly.SelectedValue = rtype;
						po_type(rtype);
						txtBPO_RLY.Visible = false;
						lstBPO_Rly.Enabled = false;
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
					lblCasNo.Text = Request.QueryString["IMMS_POKEY"].ToString();
					lblCasNo.Visible = true;
					search();

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
				string str1 = "select RITES_CASE_NO,IMMS_POKEY,IMMS_RLY_CD, RLY_CD, NVL(PURCHASER_CD,0) PURCHASER_CD,IMMS_PURCHASER_CD,IMMS_PURCHASER_DETAIL,STOCK_NONSTOCK,INSPECTING_AGENCY, PO_OR_LETTER, PO_NO,to_char(PO_DT,'dd/mm/yyyy')PO_DT,L5NO_PO,NVL(VEND_CD,0)VEND_CD, IMMS_VENDOR_CD, IMMS_VENDOR_NAME||','||IMMS_VENDOR_DETAIL VENDOR,IMMS_RLY_SHORTNAME,NVL(REGION_CODE,0) REGION_CODE,REMARKS,NVL(BPO_CD,0) BPO_CD, IMMS_BPO_CD, IMMS_BPO_NAME BPO,POI_CD,TO_CHAR(PO_DT,'YYYY') PO_YR,IMMS_POI_NAME||','||IMMS_POI_DETAIL MFG from IMMS_RITES_PO_HDR where IMMS_POKEY='" + lblCasNo.Text + "' AND IMMS_RLY_CD='" + lblRCD.Text + "'";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand cmd = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = cmd;
				da.Fill(reader, "Table");
				conn1.Close();
				HyperLink1.NavigateUrl = "https://www.ireps.gov.in/ireps/etender/pdfdocs/MMIS/PO/" + Convert.ToString(reader.Tables[0].Rows[0]["PO_YR"]) + "/" + lblRCD.Text + "/" + Convert.ToString(reader.Tables[0].Rows[0]["PO_NO"]) + ".pdf";
				HyperLink1.Target = "_blank";
				lblCasNo.Text = Convert.ToString(reader.Tables[0].Rows[0]["IMMS_POKEY"]);

				ddlSNS.SelectedValue = Convert.ToString(reader.Tables[0].Rows[0]["STOCK_NONSTOCK"]);

				ddlPOLetter.SelectedValue = Convert.ToString(reader.Tables[0].Rows[0]["PO_OR_LETTER"]);

				//ddlInspAgency.SelectedValue=Convert.ToString(reader.Tables[0].Rows[0]["INSPECTING_AGENCY"]);

				if (Convert.ToString(reader.Tables[0].Rows[0]["REGION_CODE"]) != "0")
				{
					lstRegionCd.SelectedValue = Convert.ToString(reader.Tables[0].Rows[0]["REGION_CODE"]);
				}
				if (Convert.ToString(reader.Tables[0].Rows[0]["PURCHASER_CD"]) != "0")
				{
					repopulate_pur_cd(Convert.ToString(reader.Tables[0].Rows[0]["PURCHASER_CD"]));
					ddlPurcherCode.SelectedValue = Convert.ToString(reader.Tables[0].Rows[0]["PURCHASER_CD"]);
					txtPurchaser.Visible = false;
					btnSPur.Visible = false;
					txtSPur.Visible = false;
					Label14.Visible = false;
				}
				else
				{
					//ddlPurcherCode.SelectedValue="0";
					conn1.Open();
					OracleCommand cmd2 = new OracleCommand("Select UNIQUE(PURCHASER_CD) from IMMS_RITES_PO_HDR WHERE IMMS_PURCHASER_CD='" + Convert.ToString(reader.Tables[0].Rows[0]["IMMS_PURCHASER_CD"]) + "' AND IMMS_RLY_CD='" + lblRCD.Text + "' AND PURCHASER_CD IS NOT NULL", conn1);
					string wpurch_cd = Convert.ToString(cmd2.ExecuteScalar());
					conn1.Close();
					if (wpurch_cd != "")
					{
						repopulate_pur_cd(wpurch_cd);
						ddlPurcherCode.SelectedValue = wpurch_cd;
						txtPurchaser.Visible = false;
						btnSPur.Visible = false;
						txtSPur.Visible = false;
						Label14.Visible = false;
					}
					else
					{
						txtSPur.Text = lstBPO_Rly.SelectedValue;
						txtPurchaser.Text = Convert.ToString(reader.Tables[0].Rows[0]["IMMS_PURCHASER_DETAIL"]);
						fill_purchaser();
					}
				}
				if (Convert.ToString(reader.Tables[0].Rows[0]["BPO_CD"]) != "0")
				{
					repopulate_bpo_cd(Convert.ToString(Convert.ToString(reader.Tables[0].Rows[0]["BPO_CD"])));
					ddlBPOCode.SelectedValue = Convert.ToString(Convert.ToString(reader.Tables[0].Rows[0]["BPO_CD"]));
					txtSBPO.Visible = false;
					btnSBPO.Visible = false;
					txtBPO.Visible = false;
				}
				else
				{
					conn1.Open();
					OracleCommand cmd2 = new OracleCommand("Select UNIQUE(BPO_CD) from IMMS_RITES_PO_HDR WHERE IMMS_BPO_CD='" + Convert.ToString(reader.Tables[0].Rows[0]["IMMS_BPO_CD"]) + "' AND IMMS_RLY_CD='" + lblRCD.Text + "' AND BPO_CD IS NOT NULL", conn1);
					string wbpo_cd = Convert.ToString(cmd2.ExecuteScalar());
					conn1.Close();
					if (wbpo_cd != "")
					{
						repopulate_bpo_cd(Convert.ToString(wbpo_cd));
						ddlBPOCode.SelectedValue = wbpo_cd;
						btnSBPO.Visible = false;
						txtSBPO.Visible = false;
						txtBPO.Visible = false;
					}
					else
					{
						txtBPO.Text = Convert.ToString(Convert.ToString(reader.Tables[0].Rows[0]["BPO"]));
						fill_BPOcd();
					}
				}
				txtPON.Text = Convert.ToString(reader.Tables[0].Rows[0]["PO_NO"]);
				txtPOLst5.Text = Convert.ToString(reader.Tables[0].Rows[0]["L5NO_PO"]);
				txtPOdate.Text = Convert.ToString(reader.Tables[0].Rows[0]["PO_DT"]);
				txtPORemarks.Text = Convert.ToString(reader.Tables[0].Rows[0]["REMARKS"]);
				lblPORemarks.Text = Convert.ToString(reader.Tables[0].Rows[0]["REMARKS"]);
				//txtDatePOrites.Text =Convert.ToString(reader.Tables[0].Rows[0]["RECV_DT"]);
				if (Convert.ToString(reader.Tables[0].Rows[0]["VEND_CD"]) != "0")
				{
					string str2 = "select VEND_CD,NVL2(ONLINE_CALL_STATUS,'ONLINE- '||(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)),(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY))) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and trim(VEND_CD)=" + Convert.ToString(reader.Tables[0].Rows[0]["VEND_CD"]) + " and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME";
					fill_vendor(str2);
					ddlVender.SelectedValue = Convert.ToString(reader.Tables[0].Rows[0]["VEND_CD"]);
					txtVend.Text = Convert.ToString(reader.Tables[0].Rows[0]["VEND_CD"]);
					btnFCList.Visible = false;
				}
				else
				{
					conn1.Open();
					OracleCommand cmd2 = new OracleCommand("Select UNIQUE(VEND_CD) from IMMS_RITES_PO_HDR WHERE IMMS_VENDOR_CD='" + Convert.ToString(reader.Tables[0].Rows[0]["IMMS_VENDOR_CD"]) + "' AND VEND_CD IS NOT NULL", conn1);
					string wvend_cd = Convert.ToString(cmd2.ExecuteScalar());
					conn1.Close();
					if (wvend_cd != "")
					{
						string str2 = "select VEND_CD,NVL2(ONLINE_CALL_STATUS,'ONLINE- '||(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)),(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY))) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and trim(VEND_CD)='" + wvend_cd + "' and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME";
						fill_vendor(str2);
						ddlVender.SelectedValue = wvend_cd;
						txtVend.Text = wvend_cd;
						btnFCList.Visible = false;
					}
					else
					{
						string str2 = "select VEND_CD,NVL2(ONLINE_CALL_STATUS,'ONLINE- '||(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)),(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY))) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and trim(UPPER(VEND_NAME)) LIKE UPPER('" + Convert.ToString(reader.Tables[0].Rows[0]["VENDOR"]).Substring(0, 5) + "%') and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME";
						int a = fill_vendor(str2);
						lblVendor.Text = Convert.ToString(reader.Tables[0].Rows[0]["VENDOR"]);
						vendor_status(ddlVender.SelectedValue);
					}
					rbs.SetFocus(txtPON);


				}
				//vendor_status(ddlVender.SelectedValue);


				if (reader.Tables[0].Rows[0]["POI_CD"].ToString() != "")
				{
					string str3 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and trim(VEND_CD)=" + reader.Tables[0].Rows[0]["POI_CD"].ToString() + " and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME";
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
				else
				{
					lblManufacturer.Text = reader.Tables[0].Rows[0]["MFG"].ToString();
					if (lblManufacturer.Text.Length >= 5)
					{
						string str3 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and trim(UPPER(VEND_NAME))=UPPER(" + reader.Tables[0].Rows[0]["MFG"].ToString().Substring(0, 5) + "%) and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME";
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
		public void fill_BPOcd()
		{

			try
			{
				ddlBPOCode.Items.Clear();
				DataSet dsP = new DataSet();
				string str1;

				str1 = "select BPO_CD,(B.BPO_CD||'-'||B.BPO_NAME||'/'||B.BPO_RLY||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)) BPO_NAME from T12_BILL_PAYING_OFFICER B, T03_CITY C where B.BPO_CITY_CD=C.CITY_CD and BPO_TYPE='R' and upper(trim(BPO_RLY))=upper(trim('" + lstBPO_Rly.SelectedValue + "')) ORDER BY B.BPO_NAME";
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
		void repopulate_bpo_cd(string bcd)
		{
			ddlBPOCode.Items.Clear();
			OracleDataReader reader;
			conn1.Open();
			//string str1 = "select BPO_CD,(BPO_NAME||'/'||BPO_RLY||'/'||BPO_ADD) BPO_NAME from T12_BILL_PAYING_OFFICER where BPO_CD='"+bcd+"' ORDER BY BPO_NAME"; 
			string str1 = "select BPO_CD,(B.BPO_CD||'-'||B.BPO_NAME||'/'||B.BPO_RLY||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)) BPO_NAME from T12_BILL_PAYING_OFFICER B, T03_CITY C where B.BPO_CITY_CD=C.CITY_CD and  B.BPO_CD='" + bcd + "' ORDER BY B.BPO_NAME";
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			ListItem lst;
			//			conn1.Open();
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


		public void fill_Rly()
		{
			lstBPO_Rly.Items.Clear();
			DataSet dsP = new DataSet();
			string str = "";
			str = "Select RLY_CD,RAILWAY from T91_RAILWAYS where RLY_CD<>'CORE' Order by RLY_CD";

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

				//str1 = "select CONSIGNEE_CD,(nvl2(trim(CONSIGNEE_FIRM),trim(CONSIGNEE_FIRM)||'/','')||nvl2(trim(CONSIGNEE_DESIG),trim(CONSIGNEE_DESIG)||'/','')||nvl2(trim(CONSIGNEE_DEPT),trim(CONSIGNEE_DEPT)||'/','')||CITY)  CONSIGNEE_NAME from T06_CONSIGNEE WHERE CONSIGNEE_FIRM='"+lblRCD.Text+"' ORDER BY CONSIGNEE_NAME"; 
				str1 = "select A.CONSIGNEE_CD,(A.CONSIGNEE_CD||'-'||nvl2(trim(A.CONSIGNEE_FIRM),trim(A.CONSIGNEE_FIRM)||'/','')||nvl2(trim(A.CONSIGNEE_DESIG),trim(CONSIGNEE_DESIG)||'/','')||nvl2(trim(A.CONSIGNEE_DEPT),trim(A.CONSIGNEE_DEPT)||'/','')||NVL2(trim(A.CONSIGNEE_ADD1),trim(A.CONSIGNEE_ADD1)||'/','')||NVL2(trim(B.LOCATION),trim(B.LOCATION)||' : '||trim(B.CITY),trim(B.CITY)))  CONSIGNEE_NAME from T06_CONSIGNEE A, T03_CITY B WHERE A.CONSIGNEE_CITY=B.CITY_CD and upper(trim(A.CONSIGNEE_FIRM))=upper(trim('" + lstBPO_Rly.SelectedValue + "')) ORDER BY (nvl2(trim(A.CONSIGNEE_DESIG),trim(A.CONSIGNEE_DESIG)||'/','')||nvl2(trim(A.CONSIGNEE_DEPT),trim(A.CONSIGNEE_DEPT)||'/','')||nvl2(trim(A.CONSIGNEE_FIRM),trim(A.CONSIGNEE_FIRM)||'/','')||NVL2(trim(A.CONSIGNEE_ADD1),trim(A.CONSIGNEE_ADD1)||'/','')||NVL2(trim(B.LOCATION),trim(B.LOCATION)||' : '||trim(B.CITY),trim(B.CITY)))";

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


		public void po_type(string rtype)
		{

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




		}


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
			//			string pt;
			//			if(Label8.Visible)
			//			{
			//				pt=ddlRCode.SelectedValue;
			//			}
			//			else
			//			{
			//				pt=ddlRNR.SelectedValue;
			//			}

			Response.Redirect("DEO_CRIS_PurchesOrderDetails.aspx?IMMS_POKEY=" + caseno + "&IMMS_RLY_CD=" + lblRCD.Text + "&PO_OR_LOA=" + ddlPOLetter.SelectedValue);
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

		protected void btnFCList_Click(object sender, System.EventArgs e)
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

		protected void ddlVender_SelectedIndexChanged_1(object sender, System.EventArgs e)
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
			Response.Redirect("DEO_CRIS_PurchesOrder1_Form.aspx");
		}


		protected void btnSPur_Click(object sender, System.EventArgs e)
		{
			fill_purchaser();
		}
		void fill_purchaser()
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


			if (lstRegionCd.SelectedValue != "" && ddlVender.SelectedValue != "" && ddlPurcherCode.SelectedValue != "" && ddlBPOCode.SelectedValue != "" && ddlManufac.SelectedValue != "")
			{
				conn1.Open();
				OracleCommand cmd = null;
				int err_code = 0;
				try
				{
					cmd = new OracleCommand("GENERATE_REAL_CASE_NO_CRIS", conn1);
					cmd.CommandType = CommandType.StoredProcedure;

					OracleParameter prm1 = new OracleParameter("IN_REGION_CD", OracleDbType.Char);
					prm1.Direction = ParameterDirection.Input;
					prm1.Value = lstRegionCd.SelectedValue;
					cmd.Parameters.Add(prm1);

					OracleParameter prm2 = new OracleParameter("IN_TEMP_POKEY", OracleDbType.Int32);
					prm2.Direction = ParameterDirection.Input;
					prm2.Value = Convert.ToString(lblCasNo.Text);
					cmd.Parameters.Add(prm2);

					OracleParameter prm21 = new OracleParameter("IN_TEMP_RLY_CD", OracleDbType.Char);
					prm21.Direction = ParameterDirection.Input;
					prm21.Value = Convert.ToString(lblRCD.Text);
					cmd.Parameters.Add(prm21);

					OracleParameter prm3 = new OracleParameter("IN_TEMP_USER_ID", OracleDbType.Varchar2);
					prm3.Direction = ParameterDirection.Input;
					prm3.Value = Convert.ToString(Session["Uname"].ToString());
					cmd.Parameters.Add(prm3);

					OracleParameter prm4 = new OracleParameter("OUT_CASE_NO", OracleDbType.Char, 9);
					//OracleParameter prm4 = new OracleParameter("OUT_CASE_NO",System.Data.OracleClient.OracleType.VarChar);
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
					lblRealCaseNO1.Text = cmd.Parameters["OUT_CASE_NO"].Value.ToString();
					lblRealCaseNO.Text = " Case No. --> " + Convert.ToString(cmd.Parameters["OUT_CASE_NO"].Value);
					send_Vendor_Email();
					btnAcceptPO.Enabled = false;
					btnSave.Enabled = false;
					btnPODetails.Enabled = false;
					DisplayAlert("Case No. --> " + lblRealCaseNO1.Text);
					//				try
					//				{
					//					File.Copy(Server.MapPath("..")+@"/RBS/Vendor/PO/"+lblCasNo.Text+".PDF", Server.MapPath("..")+@"/RBS/CASE_NO/"+lblRealCaseNO1.Text+".PDF");
					//					DisplayAlert("File Copied!!!");
					//					//DisplayAlert(Server.MapPath(".."));
					//
					//				}
					//				catch(Exception ex)
					//				{
					//					string str;
					//					str = ex.Message;
					//					DisplayAlert(Server.MapPath("..")+" & "+ str);
					//				}

				}
			}
			else
			{
				DisplayAlert("Inspection Region, Vendor, Purchase, BPO & Place of Inspection is compulsory, soo kindly fill them first then click in Accept PO Button");
			}

		}

		protected void lstBPO_Rly_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lblRCD.Text = lstBPO_Rly.SelectedValue;
			lblRailway.Text = lstBPO_Rly.SelectedItem.Text;
			//ptype=lblRailway.Text;
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
				rtype = lstBPO_Rly.SelectedValue;
				po_type(rtype);



			}
			fill_consignee_purcher();
		}

		// ------------------ Button Save Function ------------------ //
		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			; try
			{
				conn1.Open();
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				ss = Convert.ToString(cmd2.ExecuteScalar());
				conn1.Close();
				update();
				DisplayAlert("Record is updated!!!");
				btnPODetails.Visible = true;
				//				if(txtPORemarks.Text.Trim()!=lblPORemarks.Text.Trim() && txtPORemarks.Text.Trim()!="")
				//				{
				//					send_vendor_remarks_email();
				//				}
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
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


				string mail_body = "Dear Sir/Madam,\n\n In Reference to your PO: No. " + txtPON.Text + " dated.  " + txtPOdate.Text + ", the Case No. is not allotted due to following Reasons: -  " + txtPORemarks.Text + ". Kindly update the Purchase order as per Reason mentioned and then delete the reason from the Remarks column and click on Save PO Button. Thanks for using RITES Inspection Services. \n NATIONAL INSPECTION HELP LINE NUMBER : 1800 425 7000 (TOLL FREE). \n\n" + wRegion + ".";
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


				string mail_body = "Dear Sir/Madam,\n\n In Reference to your PO: No. " + txtPON.Text + " dated.  " + txtPOdate.Text + " the Case No. alloted is  -  " + lblRealCaseNO1.Text + ". Kindly mention this Case No. while placing call on RITES. Thanks for using RITES Inspection Services. \n NATIONAL INSPECTION HELP LINE NUMBER : 1800 425 7000 (TOLL FREE). \n\n" + wRegion + ".";
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
				conn1.Open();
				OracleCommand cmd4 = new OracleCommand("update IMMS_RITES_PO_HDR set RECV_DATE=to_date('" + txtDatePOrites.Text + "','dd/mm/yyyy'),REGION_CODE='" + lstRegionCd.SelectedValue + "',PURCHASER_CD='" + ddlPurcherCode.SelectedValue + "',RLY_CD = '" + lstBPO_Rly.SelectedItem.Value + "',REMARKS='" + txtPORemarks.Text.Trim() + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),USER_ID='" + Session["Uname"].ToString() + "',POI_CD=" + txtMName.Text.Trim() + ", VEND_CD=" + txtVend.Text.Trim() + ", BPO_CD='" + ddlBPOCode.SelectedValue + "' where IMMS_POKEY = '" + lblCasNo.Text + "' AND IMMS_RLY_CD='" + lblRCD.Text + "'", conn1);
				cmd4.ExecuteNonQuery();
				caseno = lblCasNo.Text;



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

		protected void btnSBPO_Click(object sender, System.EventArgs e)
		{
			fill_bpo();
		}

		void fill_bpo()
		{
			ddlBPOCode.Items.Clear();
			DataSet dsP = new DataSet();
			string str1 = "Select BPO_CD, (BPO_CD||'-'||BPO) BPO from V12_BILL_PAYING_OFFICER where upper(trim(BPO)) like trim(upper('" + txtSBPO.Text.Trim() + "%')) or BPO_CD='" + txtSBPO.Text.Trim() + "' order by V12_BILL_PAYING_OFFICER.BPO";
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
				rbs.SetFocus(ddlBPOCode);


			}
		}

		protected void btnSaveRemarks_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn1.Open();
				OracleCommand cmd_rem = new OracleCommand("update IMMS_RITES_PO_HDR set REMARKS='" + txtPORemarks.Text.Trim() + "' where IMMS_POKEY = '" + lblCasNo.Text + "' AND IMMS_RLY_CD='" + lblRCD.Text + "'", conn1);
				cmd_rem.ExecuteNonQuery();
				conn1.Close();
				DisplayAlert("Record is updated!!!");

				//				if(txtPORemarks.Text.Trim()!=lblPORemarks.Text.Trim() && txtPORemarks.Text.Trim()!="")
				//				{
				//					send_vendor_remarks_email();
				//				}
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
			}
		}

	}
}