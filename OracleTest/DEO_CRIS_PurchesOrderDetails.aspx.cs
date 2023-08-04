using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.DEO_CRIS_PurchesOrderDetails
{
	public partial class DEO_CRIS_PurchesOrderDetails : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		public string CASE_NO, ITEM_SRNO, RLYCD, IRLYCD;
		public string ptype;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnSBPO.Attributes.Add("OnClick", "JavaScript:validate1(txtSBPO);");
			btnSCon.Attributes.Add("OnClick", "JavaScript:validate1(txtSCon);");

			if (Convert.ToString(Request.Params["ITEM_SRNO"]) != null)
			{
				CASE_NO = Request.Params["IMMS_POKEY"].ToString();
				IRLYCD = Request.Params["IMMS_RLY_CD"].ToString();
				ITEM_SRNO = Request.Params["ITEM_SRNO"].ToString();
				Label2.Text = Request.Params["IMMS_POKEY"].ToString();
				lblIRCD.Text = Request.Params["IMMS_RLY_CD"].ToString();


				//cas_no1=Request.Params["Cs_No1"].ToString();	

			}
			else
			{
				CASE_NO = Request.Params["IMMS_POKEY"].ToString();
				Label2.Text = Request.Params["IMMS_POKEY"].ToString();
				IRLYCD = Request.Params["IMMS_RLY_CD"].ToString();
				lblIRCD.Text = Request.Params["IMMS_RLY_CD"].ToString();

			}

			if (!IsPostBack)
			{
				conn1.Open();
				OracleCommand cmd = new OracleCommand("select RLY_CD from T91_RAILWAYS WHERE IMMS_RLY_CD='" + lblIRCD.Text + "'", conn1);
				lblRCD.Text = Convert.ToString(cmd.ExecuteScalar());
				conn1.Close();

				fill_UOM();
				if (Convert.ToString(Request.Params["ITEM_SRNO"]) == null)
				{

					fillgrid1();
					fill_Consignee_BPO();

				}
				else
				{
					fill_Consignee_BPO();
					search1();

				}
				getuomfactor();




			}


		}
		//			public void match()
		//			{
		//				try
		//				{
		//					//cas_no1=Request.QueryString["case_no1"].ToString();
		//					CASE_NO=Request.QueryString["CASE_NO"].ToString();
		//					string str2 = "select CASE_NO from T82_PO_DETAIL where CASE_NO= '" + CASE_NO + "'";  
		//					Label2.Text=CASE_NO;
		//					CsNo=Label2.Text;
		//					OracleCommand cmd1 = new OracleCommand(str2, conn1);
		//					conn1.Open(); 
		//					CD = Convert.ToString(cmd1.ExecuteScalar());
		//					conn1.Close();
		//					if(CD!="") 
		//					{ 
		//						fillgrid1();
		//					}
		//					else
		//					{
		//						Label2.Text=CASE_NO;
		//						btnSave.Visible=true;
		//						
		//					}
		//				}
		//				catch(Exception ex)
		//				{
		//					string str;
		//					str = ex.Message;
		//					string str1=str.Replace("\n","");
		//					Response.Redirect(("../Error_Form.aspx?err=" + str1));
		//				}
		//				finally
		//				{
		//					conn1.Close();
		//				}
		//			}

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

		// ------------------ Saving And Updating Records in Table ------------------ //

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			conn1.Open();
			//			if(txtPLNO.Text.Trim()=="")
			//			{
			//				DisplayAlert("In railway Purchase orders PL No. is compulsary, kindly enter the PL No.");
			//			}
			//			else
			//			{

			try
			{
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy')from dual", conn1);
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				string str_PL = "select ITEM_CD from T62_MASTER_ITEM_PLNO where PL_NO='" + txtPLNO.Text.Trim() + "'";
				OracleCommand myOracleCommand = new OracleCommand(str_PL, conn1);
				string icd = Convert.ToString(myOracleCommand.ExecuteScalar());
				if (icd != "")
				{
					lblMasterItem.Text = icd;
					//ddlMasterItems.Enabled=false;
				}
				else
				{
					lblMasterItem.Text = "";
				}
				if (ddlConsigneeCD.SelectedValue != "0" && ddlBPOCode.SelectedValue != "0")
				{
					OracleCommand cmd = new OracleCommand("update IMMS_RITES_PO_DETAIL set CONSIGNEE_CD=" + ddlConsigneeCD.SelectedValue + ",USER_ID='" + Session["VEND_CD"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'), UOM_CD='" + ddlUOMCode.SelectedValue + "', PL_NO='" + txtPLNO.Text + "', ITEM_CD='" + lblMasterItem.Text + "' where IMMS_POKEY = '" + Label2.Text + "' AND IMMS_RLY_CD='" + lblIRCD.Text + "' And IMMS_CONSIGNEE_CD = '" + lblIMMS_CON_CD.Text + "' AND ITEM_SRNO=" + Label3.Text, conn1);
					cmd.ExecuteNonQuery();

					CASE_NO = Label2.Text;
					conn1.Close();
					fillgrid1();
					btnSave.Visible = false;
				}
				else
				{
					DisplayAlert("Select Consignee & BPO from given List before saving the record!!!");
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
				conn1.Dispose();
			}
			//			}
		}
		// ------------------ Saving Record in Table ------------------ //

		// ------------------ Updating Record in Table ------------------ //

		// ------------------ Deleting Record in Table ------------------ //
		//		private void btnDelete_Click(object sender, System.EventArgs e)
		//		{
		//			conn1.Open(); 
		//			try
		//			{	
		//				OracleCommand cmd1 =new OracleCommand("select NVL(count(*),0) from T18_CALL_DETAILS where CASE_NO = '" + Label2.Text + "' And ITEM_SRNO_PO = " + txtItemSLNo.Text + "",conn1);
		//				int nos=Convert.ToInt32(cmd1.ExecuteScalar());
		//				if(nos==0)
		//				{
		//					OracleCommand cmd =new OracleCommand ("delete T82_PO_DETAIL where CASE_NO = '" + Label2.Text + "'And ITEM_SRNO=" + txtItemSLNo.Text + "",conn1);
		//					cmd.ExecuteNonQuery();
		//					conn1.Close();
		//					Label2.Text=CsNo;
		//					CASE_NO=Label2.Text;
		//					btnSave.Visible=false;
		//					btnAdd.Visible=true;
		//					
		//					btnCancel.Visible=true;
		//					clear1();
		//					fillgrid1();
		//				}
		//				else
		//				{
		//					DisplayAlert("This Item Cannot be deleted, Because the item is marked in Call!!!");
		//				}
		//			}
		//			catch(Exception ex)
		//			{
		//				string str;
		//				str = ex.Message;
		//				string str1=str.Replace("\n","");
		//				Response.Redirect(("../Error_Form.aspx?err=" + str1));
		//			}
		//			finally
		//			{
		//				conn1.Close();
		//			}
		//		}
		// ------------------ Show All Records From Database Into DataGrid ------------------ //
		public void fillgrid1()
		{
			OracleDataAdapter da;
			conn1.Open();
			da = new OracleDataAdapter("Select p.IMMS_POKEY, p.IMMS_RLY_CD,p.ITEM_SRNO,p.ITEM_DESC,NVL2(p.CONSIGNEE_CD,(C.CONSIGNEE_CD||'-'||nvl2(trim(C.CONSIGNEE_DESIG),trim(C.CONSIGNEE_DESIG)||'/','')||nvl2(trim(C.CONSIGNEE_DEPT),trim(C.CONSIGNEE_DEPT)||'/','')||nvl2(trim(C.CONSIGNEE_FIRM),trim(C.CONSIGNEE_FIRM)||'/','')||NVL2(trim(C.CONSIGNEE_ADD1),trim(C.CONSIGNEE_ADD1)||'/','')||NVL2(trim(D.LOCATION),trim(D.LOCATION)||' : '||trim(D.CITY),trim(D.CITY))),p.IMMS_CONSIGNEE_NAME||'/'||p.IMMS_CONSIGNEE_DETAIL) CONSIGNEE_NAME,p.QTY,p.RATE,p.VALUE from IMMS_RITES_PO_DETAIL p,T06_CONSIGNEE C,T03_CITY D where p.CONSIGNEE_CD=C.CONSIGNEE_CD(+) AND C.CONSIGNEE_CITY=D.CITY_CD(+) And IMMS_POKEY='" + Label2.Text + "' AND IMMS_RLY_CD='" + lblIRCD.Text + "' Order by p.ITEM_SRNO", conn1);//And ITEM_SRNO='" + txtItemSLNo.Text + "'
			DataSet ds = new DataSet();
			da.Fill(ds, "IMMS_RITES_PO_DETAIL");
			if (ds.Tables[0].Rows.Count == 0)
			{
				//					DisplayAlert("No Record Found!!!");
				DgPO.Visible = false;
			}
			else
			{
				DgPO.Visible = true;
				DgPO.DataSource = ds;
				DgPO.DataBind();
			}
			conn1.Close();
		}


		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		public void fill_UOM()
		{
			try
			{
				ddlUOMCode.Items.Clear();
				DataSet dsP = new DataSet();
				string str1 = "select UOM_CD,UOM_L_DESC from T04_UOM ORDER BY UOM_S_DESC";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				ListItem lst;
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					lst = new ListItem();
					lst.Text = dsP.Tables[0].Rows[i]["UOM_L_DESC"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["UOM_CD"].ToString();
					ddlUOMCode.Items.Add(lst);
				}
				ddlUOMCode.SelectedValue = "3";
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("../Error_Form.aspx?err=" + str1));
			}
		}
		// ------------------ Searching And Showing Records From Table ------------------ //
		public void search1()
		{
			conn1.Open();
			try
			{
				OracleCommand cmd = new OracleCommand("select D.IMMS_POKEY,D.IMMS_RLY_CD,ITEM_SRNO,SUBSTR(replace(ITEM_DESC,chr(39),''),0,400) ITEM_DESC,NVL(CONSIGNEE_CD,0) CONSIGNEE_CD,IMMS_CONSIGNEE_CD,IMMS_CONSIGNEE_CD||'-'||IMMS_CONSIGNEE_NAME||'/'||IMMS_CONSIGNEE_DETAIL CONSIGNEE,NVL(H.BPO_CD,0) BPO_CD, H.IMMS_BPO_CD, H.IMMS_BPO_NAME||'/'||H.IMMS_BPO_DETAIL BPO, QTY,NVL(D.UOM_CD,0) UOM_CD,U.UOM_CD UOM, D.IMMS_UOM_CD, IMMS_UOM_DESC,RATE,BASIC_VALUE,SALES_TAX_PER,SALES_TAX,EXCISE_TYPE,EXCISE_PER,EXCISE,DISCOUNT_TYPE,DISCOUNT_PER,DISCOUNT,OT_CHARGE_TYPE,OT_CHARGE_PER,OT_CHARGES,VALUE,to_char(DELV_DT,'dd/mm/yyyy') DELV_DT,to_char(EXT_DELV_DT,'dd/mm/yyyy') EXT_DELV_DT, PL_NO from IMMS_RITES_PO_DETAIL D, IMMS_RITES_PO_HDR H, T04_UOM U where H.IMMS_POKEY=D.IMMS_POKEY AND H.IMMS_RLY_CD=D.IMMS_RLY_CD AND D.IMMS_UOM_CD=U.IMMS_UOM_CD(+) AND D.IMMS_POKEY='" + CASE_NO + "' AND D.IMMS_RLY_CD='" + lblIRCD.Text + "' And ITEM_SRNO=" + ITEM_SRNO, conn1);
				OracleDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					Label2.Text = Convert.ToString(reader["IMMS_POKEY"]);
					lblIRCD.Text = Convert.ToString(reader["IMMS_RLY_CD"]);
					Label3.Text = Convert.ToString(reader["ITEM_SRNO"]);
					txtItemSLNo.Text = Convert.ToString(reader["ITEM_SRNO"]);
					txtItemDescpt.Text = Convert.ToString(reader["ITEM_DESC"]);
					if (Convert.ToString(reader["CONSIGNEE_CD"]) != "0")
					{
						repopulate_con_cd(Convert.ToString(reader["CONSIGNEE_CD"]));
						ddlConsigneeCD.SelectedValue = Convert.ToString(reader["CONSIGNEE_CD"]);
						btnSCon.Visible = false;
						txtSCon.Visible = false;
						Label7.Visible = false;
					}
					else
					{

						OracleCommand cmd2 = new OracleCommand("Select UNIQUE(CONSIGNEE_CD) from IMMS_RITES_PO_DETAIL WHERE IMMS_CONSIGNEE_CD='" + Convert.ToString(reader["IMMS_CONSIGNEE_CD"]) + "' AND IMMS_RLY_CD='" + lblIRCD.Text + "' AND CONSIGNEE_CD IS NOT NULL", conn1);
						string wcons_cd = Convert.ToString(cmd2.ExecuteScalar());

						if (wcons_cd != "")
						{
							repopulate_con_cd(wcons_cd);
							ddlConsigneeCD.SelectedValue = wcons_cd;
							txtConsignee.Visible = false;
							btnSCon.Visible = false;
							txtSCon.Visible = false;
							Label7.Visible = false;
							txtConsignee.Visible = false;
						}
						else
						{
							txtConsignee.Text = Convert.ToString(reader["CONSIGNEE"]);
						}
					}
					lblIMMS_CON_CD.Text = Convert.ToString(reader["IMMS_CONSIGNEE_CD"]);
					if (Convert.ToString(reader["BPO_CD"]) != "0")
					{
						repopulate_bpo_cd(Convert.ToString(reader["BPO_CD"]));
						ddlBPOCode.SelectedValue = Convert.ToString(reader["BPO_CD"]);
						txtSBPO.Visible = false;
						btnSBPO.Visible = false;
						txtBPO.Visible = false;
						Label15.Visible = false;
					}
					else
					{
						txtBPO.Text = Convert.ToString(reader["BPO"]);
					}
					//lblOldConCD.Text=Convert.ToString(reader["CONSIGNEE_CD"]);


					txtQty.Text = Convert.ToString(reader["QTY"]);
					txtBaseValue.Text = Convert.ToString(reader["BASIC_VALUE"]);
					txtRate.Text = Convert.ToString(reader["RATE"]);
					if (Convert.ToString(reader["UOM_CD"]) != "0")
					{
						ddlUOMCode.SelectedValue = Convert.ToString(reader["UOM"]);
					}
					else if (Convert.ToString(reader["UOM_CD"]) == "0" && Convert.ToString(reader["UOM"]) != "0")
					{
						ddlUOMCode.SelectedValue = Convert.ToString(reader["UOM"]);
					}
					else
					{
						lblUOM.Text = Convert.ToString(reader["IMMS_UOM_DESC"]);
					}

					txtSaleTaxPre.Text = Convert.ToString(reader["SALES_TAX_PER"]);
					txtSaleTaxAmt.Text = Convert.ToString(reader["SALES_TAX"]);
					ddlExciseType.SelectedValue = Convert.ToString(reader["EXCISE_TYPE"]);
					txtExcise.Text = Convert.ToString(reader["EXCISE_PER"]);
					txtExciseAmt.Text = Convert.ToString(reader["EXCISE"]);
					ddlDiscountType.SelectedValue = Convert.ToString(reader["DISCOUNT_TYPE"]);
					txtDiscountPer.Text = Convert.ToString(reader["DISCOUNT_PER"]);
					txtDiscountAmt.Text = Convert.ToString(reader["DISCOUNT"]);
					ddlOCType.SelectedValue = Convert.ToString(reader["OT_CHARGE_TYPE"]);
					txtOtherCharges.Text = Convert.ToString(reader["OT_CHARGE_PER"]);
					txtOtherChargesAmt.Text = Convert.ToString(reader["OT_CHARGES"]);
					txtValue.Text = Convert.ToString(reader["VALUE"]);
					//ddlBPOCode.SelectedValue = Convert.ToString(reader["BPO_CD"]);
					//txtManfctPlace.Text = Convert.ToString(reader["MANUFACTURE_PLACE"]);
					txtDelvDate.Text = Convert.ToString(reader["DELV_DT"]);
					if (Convert.ToString(reader["EXT_DELV_DT"]) == "")
					{
						txtExtDelvDate.Text = Convert.ToString(reader["DELV_DT"]);
					}
					else
					{
						txtExtDelvDate.Text = Convert.ToString(reader["EXT_DELV_DT"]);
					}
					txtPLNO.Text = Convert.ToString(reader["PL_NO"]);
				}

				btnSave.Visible = true;
				reader.Close();
				conn1.Close();
				fillgrid1();
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("../Error_Form.aspx?err=" + str1));
			}
		}
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			//			Label2.Text= CsNo;
			//			fill_ConsigneeCd();
			//fill_BPOcd();
			fill_UOM();
			clear1();
			txtBPO.Text = "";
			txtConsignee.Text = "";
			btnSave.Visible = true;

			//			getisrno();
			fill_Consignee_BPO();
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{

			Response.Redirect("DEO_CRIS_PurchesOrder_Form.aspx?IMMS_POKEY=" + Label2.Text.Trim() + "&IMMS_RLY_CD=" + lblIRCD.Text);
		}
		public void clear1()
		{
			txtItemSLNo.Text = "";
			txtItemDescpt.Text = "";
			txtQty.Text = "";
			txtRate.Text = "";
			txtSaleTaxAmt.Text = "";
			txtExcise.Text = "";
			txtBaseValue.Text = "";
			txtSaleTaxPre.Text = "";
			txtExciseAmt.Text = "";
			txtDiscountPer.Text = "";
			txtDiscountAmt.Text = "";
			txtOtherCharges.Text = "";
			txtValue.Text = "";
			//txtManfctPlace.Text="";
			txtDelvDate.Text = "";
			txtExtDelvDate.Text = "";
			txtOtherChargesAmt.Text = "";
			ddlOCType.SelectedIndex = 0;
			ddlDiscountType.SelectedIndex = 0;
			ddlExciseType.SelectedIndex = 0;
			//btnAdd.Visible=true;
		}


		void getuomfactor()
		{
			try
			{
				string str1 = "select UOM_FACTOR from T04_UOM where UOM_CD=" + ddlUOMCode.SelectedValue;
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				decimal factor = Convert.ToDecimal(myOracleCommand.ExecuteScalar());
				conn1.Close();
				txtUOMFactor.Text = factor.ToString();
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("../Error_Form.aspx?err=" + str1));
			}
		}


		//		void getisrno()
		//		{
		//			try
		//			{
		//				//string str1 = "select nvl(max(ITEM_SRNO),0)+1  from T15_PO_DETAIL where CASE_NO='"+CsNo+"' and CONSIGNEE_CD="+ddlConsigneeCD.SelectedValue+"" ; 
		//				string str1 = "select nvl(max(ITEM_SRNO),0)+1  from T82_PO_DETAIL where CASE_NO='"+CsNo+"'" ; 
		//				OracleCommand myOracleCommand = new OracleCommand(str1, conn1); 
		//				conn1.Open();
		//				int isrno=Convert.ToInt32(myOracleCommand.ExecuteScalar());
		//				conn1.Close();
		//				txtItemSLNo.Text=isrno.ToString();
		//				Label3.Text=isrno.ToString();
		//
		//			}
		//			catch(Exception ex)
		//			{
		//				string str;
		//				str = ex.Message;
		//				string str1=str.Replace("\n","");
		//				Response.Redirect(("../Error_Form.aspx?err=" + str1));
		//			}
		//		}
		protected void ddlUOMCode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			getuomfactor();
			rbs.SetFocus(txtRate);

		}
		public void fill_Consignee_BPO()
		{
			string client = "";

			try
			{
				OracleCommand cmd = new OracleCommand("select H.RLY_CD from IMMS_RITES_PO_HDR H, T91_RAILWAYS R  where R.IMMS_RLY_CD=H.IMMS_RLY_CD AND H.IMMS_POKEY='" + Label2.Text + "' AND H.IMMS_RLY_CD='" + lblIRCD.Text + "'", conn1);
				conn1.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					client = Convert.ToString(reader["RLY_CD"]).Trim();

				}
				reader.Close();
				ddlConsigneeCD.Items.Clear();
				DataSet dsP = new DataSet();
				string str1;


				str1 = "select A.CONSIGNEE_CD,(A.CONSIGNEE_CD||'-'||nvl2(trim(A.CONSIGNEE_DESIG),trim(A.CONSIGNEE_DESIG)||'/','')||nvl2(trim(A.CONSIGNEE_DEPT),trim(A.CONSIGNEE_DEPT)||'/','')||nvl2(trim(A.CONSIGNEE_FIRM),trim(A.CONSIGNEE_FIRM)||'/','')||NVL2(trim(A.CONSIGNEE_ADD1),trim(A.CONSIGNEE_ADD1)||'/','')||NVL2(trim(B.LOCATION),trim(B.LOCATION)||' : '||trim(B.CITY),trim(B.CITY))) CONSIGNEE_NAME from T06_CONSIGNEE A, T03_CITY B WHERE A.CONSIGNEE_CITY=B.CITY_CD and A.CONSIGNEE_TYPE='R' AND upper(trim(A.CONSIGNEE_FIRM))=upper(trim('" + lblRCD.Text + "')) ORDER BY (nvl2(trim(A.CONSIGNEE_DESIG),trim(A.CONSIGNEE_DESIG)||'/','')||nvl2(trim(A.CONSIGNEE_DEPT),trim(A.CONSIGNEE_DEPT)||'/','')||nvl2(trim(A.CONSIGNEE_FIRM),trim(A.CONSIGNEE_FIRM)||'/','')||NVL2(trim(A.CONSIGNEE_ADD1),trim(A.CONSIGNEE_ADD1)||'/','')||NVL2(trim(B.LOCATION),trim(B.LOCATION)||' : '||trim(B.CITY),trim(B.CITY)))";

				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				ListItem lst;
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				conn1.Close();
				int i;
				for (i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					lst = new ListItem();
					lst.Text = dsP.Tables[0].Rows[i]["CONSIGNEE_NAME"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["CONSIGNEE_CD"].ToString();
					ddlConsigneeCD.Items.Add(lst);
				}
				lst = new ListItem();
				lst.Text = "Other";
				lst.Value = "0";
				ddlConsigneeCD.Items.Insert(i, lst);
				ddlBPOCode.Items.Clear();
				DataSet dsP1 = new DataSet();
				string str2;


				str2 = "select BPO_CD,(B.BPO_CD||'-'||B.BPO_NAME||'/'||B.BPO_RLY||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)) BPO_NAME from T12_BILL_PAYING_OFFICER B, T03_CITY C where B.BPO_CITY_CD=C.CITY_CD and BPO_TYPE='R' and upper(trim(BPO_RLY))=upper(trim('" + lblRCD.Text + "')) ORDER BY B.BPO_NAME";
				//				}
				OracleDataAdapter da1 = new OracleDataAdapter(str2, conn1);
				OracleCommand myOracleCommand1 = new OracleCommand(str2, conn1);
				ListItem lst1;
				da1.SelectCommand = myOracleCommand1;
				da1.Fill(dsP1, "Table");
				int f;
				for (f = 0; f <= dsP1.Tables[0].Rows.Count - 1; f++)
				{
					lst1 = new ListItem();
					lst1.Text = dsP1.Tables[0].Rows[f]["BPO_NAME"].ToString();
					lst1.Value = dsP1.Tables[0].Rows[f]["BPO_CD"].ToString();
					ddlBPOCode.Items.Add(lst1);
				}
				lst = new ListItem();
				lst.Text = "Other";
				lst.Value = "0";
				ddlBPOCode.Items.Insert(f, lst);
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
		}

		//		private void btnSearch_Click(object sender, System.EventArgs e)
		//		{
		//			string sql="Select p.CASE_NO,p.ITEM_SRNO,p.ITEM_DESC,(C.CONSIGNEE_CD||'-'||nvl2(trim(C.CONSIGNEE_DESIG),trim(C.CONSIGNEE_DESIG)||'/','')||nvl2(trim(C.CONSIGNEE_DEPT),trim(C.CONSIGNEE_DEPT)||'/','')||nvl2(trim(C.CONSIGNEE_FIRM),trim(C.CONSIGNEE_FIRM)||'/','')||NVL2(trim(C.CONSIGNEE_ADD1),trim(C.CONSIGNEE_ADD1)||'/','')||NVL2(trim(D.LOCATION),trim(D.LOCATION)||' : '||trim(D.CITY),trim(D.CITY))) CONSIGNEE_NAME,p.QTY,p.RATE,p.VALUE from T82_PO_DETAIL p,T06_CONSIGNEE C,T03_CITY D where p.CONSIGNEE_CD=C.CONSIGNEE_CD AND C.CONSIGNEE_CITY=D.CITY_CD And CASE_NO='"+Label2.Text +"' ";
		//			if(ddlConsigneeCD.SelectedValue!="")
		//			{
		//			sql= sql + " and p.CONSIGNEE_CD="+ddlConsigneeCD.SelectedValue;
		//			}
		//			if (txtItemDescpt.Text.Trim()!="")
		//			{
		//			sql= sql + " and (instr(upper(p.ITEM_DESC),upper('"+txtItemDescpt.Text.Trim()+"'))>0)";
		//			}
		//			sql= sql + " Order by p.ITEM_SRNO";
		//			OracleDataAdapter da;
		//			conn1.Open();
		//			da=new OracleDataAdapter(sql,conn1);//And ITEM_SRNO='" + txtItemSLNo.Text + "'
		//			DataSet ds=new DataSet();
		//			da.Fill(ds,"T82_PO_DETAIL");
		//			if(ds.Tables[0].Rows.Count==0)
		//			{
		//				DisplayAlert("No Record Found!!!");
		//				DgPO.Visible =false;
		//			}
		//			else
		//			{
		//				DgPO.Visible =true;
		//				DgPO.DataSource=ds;
		//				DgPO.DataBind();
		//			}
		//
		//			conn1.Close();
		//		}

		//		private void btnShowAll_Click(object sender, System.EventArgs e)
		//		{
		//		fillgrid1();
		//		ddlConsigneeCD.SelectedIndex=0;
		//		txtItemDescpt.Text="";
		//		
		//		}

		protected void btnSBPO_Click(object sender, System.EventArgs e)
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
		void repopulate_bpo_cd(string bcd)
		{
			ddlBPOCode.Items.Clear();
			OracleDataReader reader;
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
			//			conn1.Close();

		}
		void repopulate_con_cd(string concd)
		{
			ddlConsigneeCD.Items.Clear();
			OracleDataReader reader;
			string str1 = "select A.CONSIGNEE_CD,(A.CONSIGNEE_CD||'-'||nvl2(trim(A.CONSIGNEE_DESIG),trim(A.CONSIGNEE_DESIG)||'/','')||nvl2(trim(A.CONSIGNEE_DEPT),trim(A.CONSIGNEE_DEPT)||'/','')||nvl2(trim(A.CONSIGNEE_FIRM),trim(A.CONSIGNEE_FIRM)||'/','')||NVL2(trim(A.CONSIGNEE_ADD1),trim(A.CONSIGNEE_ADD1)||'/','')||NVL2(trim(B.LOCATION),trim(B.LOCATION)||' : '||trim(B.CITY),trim(B.CITY))) CONSIGNEE_NAME from T06_CONSIGNEE A, T03_CITY B WHERE A.CONSIGNEE_CITY=B.CITY_CD and A.CONSIGNEE_CD='" + concd + "' ORDER BY CONSIGNEE_NAME";
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
					lst.Text = reader["CONSIGNEE_NAME"].ToString();
					lst.Value = reader["CONSIGNEE_CD"].ToString();
					ddlConsigneeCD.Items.Add(lst);
				}
				ddlConsigneeCD.Visible = true;
				ddlConsigneeCD.SelectedIndex = 0;
				//rbs.SetFocus(ddlVender);


			}
			//			conn1.Close();

		}
		protected void btnSCon_Click(object sender, System.EventArgs e)
		{

			try
			{
				if (Convert.ToInt32(txtSCon.Text) >= 1 && Convert.ToInt32(txtSCon.Text) <= 99999999)
				{
					ddlConsigneeCD.Items.Clear();
					DataSet dsP = new DataSet();
					string str1 = "Select CONSIGNEE_CD, (CONSIGNEE_CD||'-'||CONSIGNEE)CONSIGNEE from V06_CONSIGNEE where CONSIGNEE_CD=" + txtSCon.Text.Trim() + " order by V06_CONSIGNEE.CONSIGNEE";
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
						rbs.SetFocus(ddlConsigneeCD);


					}
				}
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = "Input string was not in a correct format.";
				if (str.Equals(str1))
				{
					ddlConsigneeCD.Items.Clear();
					DataSet dsP = new DataSet();
					string str11 = "Select CONSIGNEE_CD, (CONSIGNEE_CD||'-'||CONSIGNEE)CONSIGNEE from V06_CONSIGNEE where upper(trim(CONSIGNEE)) like trim(upper('" + txtSCon.Text.Trim() + "%')) order by V06_CONSIGNEE.CONSIGNEE";
					OracleDataAdapter da = new OracleDataAdapter(str11, conn1);
					OracleCommand myOracleCommand = new OracleCommand(str11, conn1);
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
				else
				{
					string str2 = str.Replace("\n", "");
					Response.Redirect("../Error_Form.aspx?err=" + str2);
				}

			}
			finally
			{
				conn1.Close();
			}
		}
	}
}