using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.DEO_Vendor_PurchesOrderDetails
{
	public partial class DEO_Vendor_PurchesOrderDetails : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		public string CASE_NO, ITEM_SRNO, PODT;
		static string CsNo;
		string CD, ss;
		public string ptype, po_or_loa;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelete.Attributes.Add("OnClick", "JavaScript:conformation();");
			btnSBPO.Attributes.Add("OnClick", "JavaScript:validate1(txtSBPO);");
			btnSCon.Attributes.Add("OnClick", "JavaScript:validate1(txtSCon);");

			if (Convert.ToString(Request.Params["ITEM_SRNO"]) != null)
			{
				CASE_NO = Request.Params["CASE_NO"].ToString();
				CsNo = Request.Params["CASE_NO"].ToString();
				ITEM_SRNO = Request.Params["ITEM_SRNO"].ToString();
				PODT = Request.Params["PODT"].ToString();
				lblPODT.Text = PODT;
				txtPODT.Text = lblPODT.Text;
				//cas_no1=Request.Params["Cs_No1"].ToString();	

			}
			else
			{
				PODT = Request.Params["PODT"].ToString();
				lblPODT.Text = PODT;
				txtPODT.Text = lblPODT.Text;
			}

			ptype = Request.Params["type"].ToString();
			po_or_loa = Request.Params["PO_OR_LOA"].ToString();
			if (!IsPostBack)
			{

				fill_UOM();
				fill_Item_Master();
				if (Convert.ToString(Request.Params["ITEM_SRNO"]) == null)
				{
					match();
					getisrno();
					fill_Consignee_BPO();
				}
				else
				{
					//fill_Item_Master();
					search1();


				}
				getuomfactor();




			}


		}
		public void match()
		{
			try
			{
				//cas_no1=Request.QueryString["case_no1"].ToString();
				CASE_NO = Request.QueryString["CASE_NO"].ToString();
				string str2 = "select CASE_NO from T82_PO_DETAIL where CASE_NO= '" + CASE_NO + "'";
				Label2.Text = CASE_NO;
				CsNo = Label2.Text;
				OracleCommand cmd1 = new OracleCommand(str2, conn1);
				conn1.Open();
				CD = Convert.ToString(cmd1.ExecuteScalar());
				conn1.Close();
				if (CD != "")
				{
					fillgrid1();
					btnDelete.Visible = true;
				}
				else
				{
					Label2.Text = CASE_NO;
					btnSave.Visible = true;
					btnDelete.Visible = false;
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

		// ------------------ Saving And Updating Records in Table ------------------ //

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			//			if(ptype=="R" && po_or_loa=="P" && txtPLNO.Text.Trim()=="")
			//			{
			//			
			//				DisplayAlert("In railway Purchase orders PL No. is compulsary, kindly enter the PL No.");
			//			}
			//			else
			//			{

			conn1.Open();
			int check = 0;
			try
			{
				OracleCommand cmd = new OracleCommand("select CASE_NO,ITEM_SRNO from T82_PO_DETAIL where CASE_NO='" + Label2.Text + "'And ITEM_SRNO='" + txtItemSLNo.Text + "' ", conn1);
				OracleDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					if (Convert.ToString(reader["CASE_NO"]).Trim() == Label2.Text.Trim() && Convert.ToString(reader["ITEM_SRNO"]).Trim() == txtItemSLNo.Text.Trim())
					{
						check = 1;
						break;
					}
					else
					{
						check = 0;
					}
				}
				reader.Close();
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

			conn1.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
			ss = Convert.ToString(cmd2.ExecuteScalar());

			string str_PL = "select ITEM_CD from T62_MASTER_ITEM_PLNO where PL_NO='" + txtPLNO.Text.Trim() + "'";
			OracleCommand myOracleCommand = new OracleCommand(str_PL, conn1);
			string icd = Convert.ToString(myOracleCommand.ExecuteScalar());
			if (icd != "")
			{
				ddlMasterItems.SelectedValue = icd;
				//ddlMasterItems.Enabled=false;
			}
			else
			{
				ddlMasterItems.SelectedValue = "Other";
			}
			conn1.Close();

			if (check == 1)
			{
				update();
			}
			else
			{
				save();
				getisrno();
			}
			//			}
		}
		// ------------------ Saving Record in Table ------------------ //
		public void save()
		{
			conn1.Open();
			try
			{
				string wConsignee = "";
				string wBPO = "";
				if (ddlBPOCode.SelectedValue == "0")
				{
					wBPO = txtBPO.Text.Trim();
				}
				if (ddlConsigneeCD.SelectedValue == "0")
				{
					wConsignee = txtConsignee.Text.Trim();
				}

				string item_cd = "";
				if (ddlMasterItems.SelectedValue == "0" || ddlMasterItems.SelectedItem.Text == "Other")
				{
					item_cd = "";
				}
				else
				{
					item_cd = ddlMasterItems.SelectedValue;
				}
				OracleCommand cmd1 = new OracleCommand("insert into T82_PO_DETAIL(CASE_NO, ITEM_SRNO, ITEM_DESC, CONSIGNEE_CD,CONSIGNEE, QTY, RATE, UOM_CD, BASIC_VALUE, SALES_TAX_PER, SALES_TAX, EXCISE_TYPE, EXCISE_PER,EXCISE, DISCOUNT_TYPE, DISCOUNT_PER, DISCOUNT, OT_CHARGE_TYPE,OT_CHARGE_PER,OTHER_CHARGES, VALUE, DELV_DT, EXT_DELV_DT, USER_ID, DATETIME,BPO_CD,BPO,ITEM_CD,PL_NO) values('" + Label2.Text + "','" + txtItemSLNo.Text + "',upper('" + txtItemDescpt.Text + "'),'" + ddlConsigneeCD.SelectedItem.Value + "','" + wConsignee + "','" + txtQty.Text + "','" + txtRate.Text + "','" + ddlUOMCode.SelectedItem.Value + "','" + txtBaseValue.Text + "','" + txtSaleTaxPre.Text + "','" + txtSaleTaxAmt.Text + "','" + ddlExciseType.SelectedValue + "','" + txtExcise.Text + "','" + txtExciseAmt.Text + "','" + ddlDiscountType.SelectedValue + "','" + txtDiscountPer.Text + "','" + txtDiscountAmt.Text + "','" + ddlOCType.SelectedValue + "'," + txtOtherCharges.Text + "," + txtOtherChargesAmt.Text + ",'" + txtValue.Text + "',to_date('" + txtDelvDate.Text + "','dd/mm/yyyy'),to_date('" + txtExtDelvDate.Text + "','dd/mm/yyyy'),'" + Session["VEND_CD"] + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),'" + ddlBPOCode.SelectedValue + "','" + wBPO + "', '" + item_cd + "','" + txtPLNO.Text.Trim() + "')", conn1);
				cmd1.ExecuteNonQuery();
				conn1.Close();
				CsNo = Label2.Text;
				//cas_no1=Label2.Text;
				fillgrid1();
				btnSave.Visible = true;
				btnAdd.Visible = false;
				btnDelete.Visible = false;
				clear1();
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
			//			string popupScript = "<script language='javascript'>" + "window.open('PopUp.aspx?str=Your Record Has Been Saved Of Case Numbe:-"+ CsNo +"','CustomPopUp', " + "'width=350, height=125, menubar=no, resizable=no')" + "</script>";
			//			Page.RegisterStartupScript("PopupScript", popupScript);
		}
		// ------------------ Updating Record in Table ------------------ //
		public void update()
		{
			conn1.Open();

			try
			{
				string item_cd = "";
				if (ddlMasterItems.SelectedValue == "0" || ddlMasterItems.SelectedItem.Text == "Other")
				{
					item_cd = "";
				}
				else
				{
					item_cd = ddlMasterItems.SelectedValue;
				}

				if (ddlConsigneeCD.SelectedValue != "0" && ddlBPOCode.SelectedValue != "0")
				{
					OracleCommand cmd = new OracleCommand("update T82_PO_DETAIL set ITEM_DESC =upper('" + txtItemDescpt.Text + "'),QTY ='" + txtQty.Text + "',CONSIGNEE_CD=" + ddlConsigneeCD.SelectedValue + ",BPO_CD='" + ddlBPOCode.SelectedValue + "',UOM_CD ='" + ddlUOMCode.SelectedItem.Value + "',BASIC_VALUE= '" + txtBaseValue.Text + "',RATE='" + txtRate.Text + "',EXCISE_TYPE='" + ddlExciseType.SelectedValue + "', EXCISE_PER = '" + txtExcise.Text + "',EXCISE ='" + txtExciseAmt.Text + "', SALES_TAX_PER ='" + txtSaleTaxPre.Text + "', SALES_TAX ='" + txtSaleTaxAmt.Text + "',DISCOUNT_TYPE='" + ddlDiscountType.SelectedValue + "', DISCOUNT_PER = '" + txtDiscountPer.Text + "',DISCOUNT ='" + txtDiscountAmt.Text + "',OT_CHARGE_TYPE='" + ddlOCType.SelectedValue + "',OT_CHARGE_PER=" + txtOtherCharges.Text + ",OTHER_CHARGES =" + txtOtherChargesAmt.Text + ",VALUE = '" + txtValue.Text + "', DELV_DT = to_date('" + txtDelvDate.Text + "','dd/mm/yyyy'),EXT_DELV_DT = to_date('" + txtExtDelvDate.Text + "','dd/mm/yyyy'),USER_ID='" + Session["VEND_CD"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'), ITEM_CD='" + item_cd + "', PL_NO='" + txtPLNO.Text.Trim() + "' where CASE_NO = '" + Label2.Text + "' And ITEM_SRNO = " + txtItemSLNo.Text + "", conn1);
					cmd.ExecuteNonQuery();

					CsNo = Label2.Text;
					CASE_NO = Label2.Text;
					conn1.Close();
					fillgrid1();
					btnDelete.Visible = false;
					btnSave.Visible = false;
					btnAdd.Visible = true;
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
			}
		}
		// ------------------ Deleting Record in Table ------------------ //
		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			conn1.Open();
			try
			{
				OracleCommand cmd1 = new OracleCommand("select NVL(count(*),0) from T18_CALL_DETAILS where CASE_NO = '" + Label2.Text + "' And ITEM_SRNO_PO = " + txtItemSLNo.Text + "", conn1);
				int nos = Convert.ToInt32(cmd1.ExecuteScalar());
				if (nos == 0)
				{
					OracleCommand cmd = new OracleCommand("delete T82_PO_DETAIL where CASE_NO = '" + Label2.Text + "'And ITEM_SRNO=" + txtItemSLNo.Text + "", conn1);
					cmd.ExecuteNonQuery();
					conn1.Close();
					Label2.Text = CsNo;
					CASE_NO = Label2.Text;
					btnSave.Visible = false;
					btnAdd.Visible = true;
					btnDelete.Visible = false;
					btnCancel.Visible = true;
					clear1();
					fillgrid1();
				}
				else
				{
					DisplayAlert("This Item Cannot be deleted, Because the item is marked in Call!!!");
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
		}
		// ------------------ Show All Records From Database Into DataGrid ------------------ //
		public void fillgrid1()
		{
			OracleDataAdapter da;
			conn1.Open();
			da = new OracleDataAdapter("Select p.CASE_NO,p.ITEM_SRNO,p.ITEM_DESC,NVL2(p.CONSIGNEE,(C.CONSIGNEE_CD||'-'||nvl2(trim(C.CONSIGNEE_DESIG),trim(C.CONSIGNEE_DESIG)||'/','')||nvl2(trim(C.CONSIGNEE_DEPT),trim(C.CONSIGNEE_DEPT)||'/','')||nvl2(trim(C.CONSIGNEE_FIRM),trim(C.CONSIGNEE_FIRM)||'/','')||NVL2(trim(C.CONSIGNEE_ADD1),trim(C.CONSIGNEE_ADD1)||'/','')||NVL2(trim(D.LOCATION),trim(D.LOCATION)||' : '||trim(D.CITY),trim(D.CITY)))||'/'||p.CONSIGNEE,(C.CONSIGNEE_CD||'-'||nvl2(trim(C.CONSIGNEE_DESIG),trim(C.CONSIGNEE_DESIG)||'/','')||nvl2(trim(C.CONSIGNEE_DEPT),trim(C.CONSIGNEE_DEPT)||'/','')||nvl2(trim(C.CONSIGNEE_FIRM),trim(C.CONSIGNEE_FIRM)||'/','')||NVL2(trim(C.CONSIGNEE_ADD1),trim(C.CONSIGNEE_ADD1)||'/','')||NVL2(trim(D.LOCATION),trim(D.LOCATION)||' : '||trim(D.CITY),trim(D.CITY)))) CONSIGNEE_NAME,p.QTY,p.RATE,p.VALUE from T82_PO_DETAIL p,T06_CONSIGNEE C,T03_CITY D where p.CONSIGNEE_CD=C.CONSIGNEE_CD AND C.CONSIGNEE_CITY=D.CITY_CD And CASE_NO='" + Label2.Text + "' Order by p.ITEM_SRNO", conn1);//And ITEM_SRNO='" + txtItemSLNo.Text + "'
			DataSet ds = new DataSet();
			da.Fill(ds, "T82_PO_DETAIL");
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
			btnShowAll.Visible = false;
			conn1.Close();
		}


		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		public void fill_Item_Master()
		{
			try
			{
				ddlMasterItems.Items.Clear();
				DataSet dsP = new DataSet();
				string str1 = "select ITEM_CD,ITEM_DESC from T61_ITEM_MASTER ORDER BY ITEM_DESC";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				ListItem lst;
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					lst = new ListItem();
					lst.Text = dsP.Tables[0].Rows[i]["ITEM_DESC"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["ITEM_CD"].ToString();
					ddlMasterItems.Items.Add(lst);
				}
				ddlMasterItems.Items.Insert(0, "Other");
				//ddlMasterItems.SelectedValue=0;
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
				OracleCommand cmd = new OracleCommand("select CASE_NO,ITEM_SRNO,ITEM_DESC,CONSIGNEE_CD,CONSIGNEE,BPO_CD,BPO,QTY,UOM_CD,RATE,BASIC_VALUE,SALES_TAX_PER,SALES_TAX,EXCISE_TYPE,EXCISE_PER,EXCISE,DISCOUNT_TYPE,DISCOUNT_PER,DISCOUNT,OT_CHARGE_TYPE,OT_CHARGE_PER,OTHER_CHARGES,VALUE,to_char(DELV_DT,'dd/mm/yyyy') DELV_DT,to_char(EXT_DELV_DT,'dd/mm/yyyy') EXT_DELV_DT,NVL(ITEM_CD,'X')ITEM_CD,PL_NO from T82_PO_DETAIL where CASE_NO='" + CASE_NO + "' And ITEM_SRNO=" + ITEM_SRNO, conn1);
				OracleDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					Label2.Text = Convert.ToString(reader["CASE_NO"]);
					Label3.Text = Convert.ToString(reader["ITEM_SRNO"]);
					txtItemSLNo.Text = Convert.ToString(reader["ITEM_SRNO"]);
					txtItemDescpt.Text = Convert.ToString(reader["ITEM_DESC"]);
					repopulate_con_cd(Convert.ToString(reader["CONSIGNEE_CD"]));
					ddlConsigneeCD.SelectedValue = Convert.ToString(reader["CONSIGNEE_CD"]);
					repopulate_bpo_cd(Convert.ToString(reader["BPO_CD"]));
					ddlBPOCode.SelectedValue = Convert.ToString(reader["BPO_CD"]);
					lblOldConCD.Text = Convert.ToString(reader["CONSIGNEE_CD"]);
					txtBPO.Text = Convert.ToString(reader["BPO"]);
					txtConsignee.Text = Convert.ToString(reader["CONSIGNEE"]);
					txtQty.Text = Convert.ToString(reader["QTY"]);
					txtBaseValue.Text = Convert.ToString(reader["BASIC_VALUE"]);
					txtRate.Text = Convert.ToString(reader["RATE"]);
					ddlUOMCode.SelectedValue = Convert.ToString(reader["UOM_CD"]);
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
					txtOtherChargesAmt.Text = Convert.ToString(reader["OTHER_CHARGES"]);
					txtValue.Text = Convert.ToString(reader["VALUE"]);
					//ddlBPOCode.SelectedValue = Convert.ToString(reader["BPO_CD"]);
					//txtManfctPlace.Text = Convert.ToString(reader["MANUFACTURE_PLACE"]);
					txtDelvDate.Text = Convert.ToString(reader["DELV_DT"]);
					txtExtDelvDate.Text = Convert.ToString(reader["EXT_DELV_DT"]);
					if (Convert.ToString(reader["ITEM_CD"]) != "X")
					{

						ddlMasterItems.SelectedValue = Convert.ToString(reader["ITEM_CD"]);
					}

					txtPLNO.Text = Convert.ToString(reader["PL_NO"]);
				}

				btnAdd.Visible = true;
				btnSave.Visible = true;
				btnDelete.Visible = true;
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
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Label2.Text = CsNo;
			//			fill_ConsigneeCd();
			//fill_BPOcd();
			fill_UOM();
			clear1();
			txtBPO.Text = "";
			txtConsignee.Text = "";
			btnSave.Visible = true;
			btnAdd.Visible = false;
			btnDelete.Visible = false;
			getisrno();
			fill_Consignee_BPO();
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{

			Response.Redirect("DEO_Vendor_PurchesOrder_Form.aspx?Action=M&case_no=" + Label2.Text.Trim());
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
			ddlMasterItems.SelectedIndex = 0;
			txtPLNO.Text = "";
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


		void getisrno()
		{
			try
			{
				//string str1 = "select nvl(max(ITEM_SRNO),0)+1  from T15_PO_DETAIL where CASE_NO='"+CsNo+"' and CONSIGNEE_CD="+ddlConsigneeCD.SelectedValue+"" ; 
				string str1 = "select nvl(max(ITEM_SRNO),0)+1  from T82_PO_DETAIL where CASE_NO='" + CsNo + "'";
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				int isrno = Convert.ToInt32(myOracleCommand.ExecuteScalar());
				conn1.Close();
				txtItemSLNo.Text = isrno.ToString();
				Label3.Text = isrno.ToString();

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("../Error_Form.aspx?err=" + str1));
			}
		}
		protected void ddlUOMCode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			getuomfactor();
			rbs.SetFocus(txtRate);

		}
		public void fill_Consignee_BPO()
		{
			string client = "";
			string rly = "";
			try
			{
				OracleCommand cmd = new OracleCommand("select RLY_NONRLY,RLY_CD from T13_PO_MASTER where CASE_NO='" + Label2.Text + "'", conn1);
				conn1.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					rly = Convert.ToString(reader["RLY_NONRLY"]).Trim();
					client = Convert.ToString(reader["RLY_CD"]).Trim();

				}
				reader.Close();
				ddlConsigneeCD.Items.Clear();
				DataSet dsP = new DataSet();
				string str1;

				if (rly == "P")
				{
					str1 = "select A.CONSIGNEE_CD,(A.CONSIGNEE_CD||'-'||nvl2(trim(A.CONSIGNEE_DESIG),trim(A.CONSIGNEE_DESIG)||'/','')||nvl2(trim(A.CONSIGNEE_DEPT),trim(A.CONSIGNEE_DEPT)||'/','')||nvl2(trim(A.CONSIGNEE_FIRM),trim(A.CONSIGNEE_FIRM)||'/','')||NVL2(trim(A.CONSIGNEE_ADD1),trim(A.CONSIGNEE_ADD1)||'/','')||NVL2(trim(B.LOCATION),trim(B.LOCATION)||' : '||trim(B.CITY),trim(B.CITY))) CONSIGNEE_NAME from T06_CONSIGNEE A, T03_CITY B WHERE A.CONSIGNEE_CITY=B.CITY_CD and A.CONSIGNEE_TYPE='P' ORDER BY (nvl2(trim(A.CONSIGNEE_DESIG),trim(A.CONSIGNEE_DESIG)||'/','')||nvl2(trim(A.CONSIGNEE_DEPT),trim(A.CONSIGNEE_DEPT)||'/','')||nvl2(trim(A.CONSIGNEE_FIRM),trim(A.CONSIGNEE_FIRM)||'/','')||NVL2(trim(A.CONSIGNEE_ADD1),trim(A.CONSIGNEE_ADD1)||'/','')||NVL2(trim(B.LOCATION),trim(B.LOCATION)||' : '||trim(B.CITY),trim(B.CITY)))";

				}
				else
				{
					if (client != "0")
					{
						str1 = "select A.CONSIGNEE_CD,(A.CONSIGNEE_CD||'-'||nvl2(trim(A.CONSIGNEE_DESIG),trim(A.CONSIGNEE_DESIG)||'/','')||nvl2(trim(A.CONSIGNEE_DEPT),trim(A.CONSIGNEE_DEPT)||'/','')||nvl2(trim(A.CONSIGNEE_FIRM),trim(A.CONSIGNEE_FIRM)||'/','')||NVL2(trim(A.CONSIGNEE_ADD1),trim(A.CONSIGNEE_ADD1)||'/','')||NVL2(trim(B.LOCATION),trim(B.LOCATION)||' : '||trim(B.CITY),trim(B.CITY))) CONSIGNEE_NAME from T06_CONSIGNEE A, T03_CITY B WHERE A.CONSIGNEE_CITY=B.CITY_CD and upper(trim(A.CONSIGNEE_FIRM))=upper(trim('" + client + "')) ORDER BY (nvl2(trim(A.CONSIGNEE_DESIG),trim(A.CONSIGNEE_DESIG)||'/','')||nvl2(trim(A.CONSIGNEE_DEPT),trim(A.CONSIGNEE_DEPT)||'/','')||nvl2(trim(A.CONSIGNEE_FIRM),trim(A.CONSIGNEE_FIRM)||'/','')||NVL2(trim(A.CONSIGNEE_ADD1),trim(A.CONSIGNEE_ADD1)||'/','')||NVL2(trim(B.LOCATION),trim(B.LOCATION)||' : '||trim(B.CITY),trim(B.CITY)))";
						txtSBPO.Visible = true;
						txtSCon.Visible = true;
						btnSBPO.Visible = true;
						btnSCon.Visible = true;
					}
					else
					{
						str1 = "select A.CONSIGNEE_CD,(A.CONSIGNEE_CD||'-'||nvl2(trim(A.CONSIGNEE_DESIG),trim(A.CONSIGNEE_DESIG)||'/','')||nvl2(trim(A.CONSIGNEE_DEPT),trim(A.CONSIGNEE_DEPT)||'/','')||nvl2(trim(A.CONSIGNEE_FIRM),trim(A.CONSIGNEE_FIRM)||'/','')||NVL2(trim(A.CONSIGNEE_ADD1),trim(A.CONSIGNEE_ADD1)||'/','')||NVL2(trim(B.LOCATION),trim(B.LOCATION)||' : '||trim(B.CITY),trim(B.CITY))) CONSIGNEE_NAME from T06_CONSIGNEE A, T03_CITY B WHERE A.CONSIGNEE_CITY=B.CITY_CD and A.CONSIGNEE_CD=0 ORDER BY (nvl2(trim(A.CONSIGNEE_DESIG),trim(A.CONSIGNEE_DESIG)||'/','')||nvl2(trim(A.CONSIGNEE_DEPT),trim(A.CONSIGNEE_DEPT)||'/','')||nvl2(trim(A.CONSIGNEE_FIRM),trim(A.CONSIGNEE_FIRM)||'/','')||NVL2(trim(A.CONSIGNEE_ADD1),trim(A.CONSIGNEE_ADD1)||'/','')||NVL2(trim(B.LOCATION),trim(B.LOCATION)||' : '||trim(B.CITY),trim(B.CITY)))";
						txtConsignee.Visible = true;
						txtBPO.Visible = true;

					}
				}

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


				str2 = "select BPO_CD,(B.BPO_CD||'-'||B.BPO_NAME||'/'||B.BPO_RLY||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)) BPO_NAME from T12_BILL_PAYING_OFFICER B, T03_CITY C where B.BPO_CITY_CD=C.CITY_CD and BPO_TYPE='" + rly + "' and upper(trim(BPO_RLY))=upper(trim('" + client + "')) ORDER BY B.BPO_NAME";
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

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			string sql = "Select p.CASE_NO,p.ITEM_SRNO,p.ITEM_DESC,(C.CONSIGNEE_CD||'-'||nvl2(trim(C.CONSIGNEE_DESIG),trim(C.CONSIGNEE_DESIG)||'/','')||nvl2(trim(C.CONSIGNEE_DEPT),trim(C.CONSIGNEE_DEPT)||'/','')||nvl2(trim(C.CONSIGNEE_FIRM),trim(C.CONSIGNEE_FIRM)||'/','')||NVL2(trim(C.CONSIGNEE_ADD1),trim(C.CONSIGNEE_ADD1)||'/','')||NVL2(trim(D.LOCATION),trim(D.LOCATION)||' : '||trim(D.CITY),trim(D.CITY))) CONSIGNEE_NAME,p.QTY,p.RATE,p.VALUE from T82_PO_DETAIL p,T06_CONSIGNEE C,T03_CITY D where p.CONSIGNEE_CD=C.CONSIGNEE_CD AND C.CONSIGNEE_CITY=D.CITY_CD And CASE_NO='" + Label2.Text + "' ";
			if (ddlConsigneeCD.SelectedValue != "")
			{
				sql = sql + " and p.CONSIGNEE_CD=" + ddlConsigneeCD.SelectedValue;
			}
			if (txtItemDescpt.Text.Trim() != "")
			{
				sql = sql + " and (instr(upper(p.ITEM_DESC),upper('" + txtItemDescpt.Text.Trim() + "'))>0)";
			}
			sql = sql + " Order by p.ITEM_SRNO";
			OracleDataAdapter da;
			conn1.Open();
			da = new OracleDataAdapter(sql, conn1);//And ITEM_SRNO='" + txtItemSLNo.Text + "'
			DataSet ds = new DataSet();
			da.Fill(ds, "T82_PO_DETAIL");
			if (ds.Tables[0].Rows.Count == 0)
			{
				DisplayAlert("No Record Found!!!");
				DgPO.Visible = false;
			}
			else
			{
				DgPO.Visible = true;
				DgPO.DataSource = ds;
				DgPO.DataBind();
			}
			btnShowAll.Visible = true;
			conn1.Close();
		}

		protected void btnShowAll_Click(object sender, System.EventArgs e)
		{
			fillgrid1();
			ddlConsigneeCD.SelectedIndex = 0;
			txtItemDescpt.Text = "";
			btnDelete.Visible = false;
		}

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