using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.PurchesOrderDetails
{
	public partial class PurchesOrderDetails : System.Web.UI.Page
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
			//			try
			//			{	
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
				fill_ConsigneeCd();
				//fill_BPOcd();
				fill_UOM();
				fill_Item_Master();
				if (Convert.ToString(Request.Params["ITEM_SRNO"]) == null)
				{
					match();
					getisrno();
				}
				else
				{
					search1();
				}
				getuomfactor();

				if (Session["Role_CD"].ToString() == "4")
				{
					btnSave.Visible = false;
					btnDelete.Visible = false;
					btnAdd.Visible = false;
				}

				if (Session["Region"].ToString() == "C")
				{
					lstItemDesc.Visible = true;
					if (Convert.ToString(Request.Params["ITEM_SRNO"]) == null)
					{
						fill_item_CR();
						fill_item_rate_CR();
						txtItemDescpt.Text = lstItemDesc.SelectedItem.Text;
					}
					else
					{
						lstItemDesc.Visible = false;
					}

				}
				else
				{
					lstItemDesc.Visible = false;
				}

			}

			//			}
			//			catch(Exception ex)
			//			{
			//				string str;
			//				str = ex.Message;
			//				string str1=str.Replace("\n","");
			//				Response.Redirect(("Error_Form.aspx?err=" + str1));
			//			}
			//			finally
			//			{
			//				conn1.Close();
			//			}
		}
		public void match()
		{
			try
			{
				//cas_no1=Request.QueryString["case_no1"].ToString();
				CASE_NO = Request.QueryString["CASE_NO"].ToString();
				string str2 = "select CASE_NO from T15_PO_DETAIL where CASE_NO= '" + CASE_NO + "'";
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
				Response.Redirect(("Error_Form.aspx?err=" + str1));
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
				OracleCommand cmd = new OracleCommand("select CASE_NO,ITEM_SRNO from T15_PO_DETAIL where CASE_NO='" + Label2.Text + "'And ITEM_SRNO='" + txtItemSLNo.Text + "' ", conn1);
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
				Response.Redirect(("Error_Form.aspx?err=" + str1));
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
			//conn1.Open();
			string icd = Convert.ToString(myOracleCommand.ExecuteScalar());
			//conn1.Close();

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
				string item_cd = "";
				if (ddlMasterItems.SelectedValue == "0" || ddlMasterItems.SelectedItem.Text == "Other")
				{
					item_cd = "";
				}
				else
				{
					item_cd = ddlMasterItems.SelectedValue;
				}

				OracleCommand cmd1 = new OracleCommand("insert into T15_PO_DETAIL(CASE_NO, ITEM_SRNO, ITEM_DESC, CONSIGNEE_CD, QTY, RATE, UOM_CD, BASIC_VALUE, SALES_TAX_PER, SALES_TAX, EXCISE_TYPE, EXCISE_PER,EXCISE, DISCOUNT_TYPE, DISCOUNT_PER, DISCOUNT, OT_CHARGE_TYPE,OT_CHARGE_PER,OTHER_CHARGES, VALUE, DELV_DT, EXT_DELV_DT, USER_ID, DATETIME,ITEM_CD,PL_NO) values('" + Label2.Text + "','" + txtItemSLNo.Text + "',upper('" + txtItemDescpt.Text + "'),'" + ddlConsigneeCD.SelectedItem.Value + "','" + txtQty.Text + "','" + txtRate.Text + "','" + ddlUOMCode.SelectedItem.Value + "','" + txtBaseValue.Text + "','" + txtSaleTaxPre.Text + "','" + txtSaleTaxAmt.Text + "','" + ddlExciseType.SelectedValue + "','" + txtExcise.Text + "','" + txtExciseAmt.Text + "','" + ddlDiscountType.SelectedValue + "','" + txtDiscountPer.Text + "','" + txtDiscountAmt.Text + "','" + ddlOCType.SelectedValue + "'," + txtOtherCharges.Text + "," + txtOtherChargesAmt.Text + ",'" + txtValue.Text + "',to_date('" + txtDelvDate.Text + "','dd/mm/yyyy'),to_date('" + txtExtDelvDate.Text + "','dd/mm/yyyy'),'" + Session["Uname"] + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'), '" + item_cd + "','" + txtPLNO.Text.Trim() + "')", conn1);
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
				Response.Redirect(("Error_Form.aspx?err=" + str1));
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
				OracleCommand cmd = new OracleCommand("update T15_PO_DETAIL set ITEM_DESC =upper('" + txtItemDescpt.Text + "'),QTY ='" + txtQty.Text + "',CONSIGNEE_CD=" + ddlConsigneeCD.SelectedValue + ",UOM_CD ='" + ddlUOMCode.SelectedItem.Value + "',BASIC_VALUE= '" + txtBaseValue.Text + "',RATE='" + txtRate.Text + "',EXCISE_TYPE='" + ddlExciseType.SelectedValue + "', EXCISE_PER = '" + txtExcise.Text + "',EXCISE ='" + txtExciseAmt.Text + "', SALES_TAX_PER ='" + txtSaleTaxPre.Text + "', SALES_TAX ='" + txtSaleTaxAmt.Text + "',DISCOUNT_TYPE='" + ddlDiscountType.SelectedValue + "', DISCOUNT_PER = '" + txtDiscountPer.Text + "',DISCOUNT ='" + txtDiscountAmt.Text + "',OT_CHARGE_TYPE='" + ddlOCType.SelectedValue + "',OT_CHARGE_PER=" + txtOtherCharges.Text + ",OTHER_CHARGES =" + txtOtherChargesAmt.Text + ",VALUE = '" + txtValue.Text + "', DELV_DT = to_date('" + txtDelvDate.Text + "','dd/mm/yyyy'),EXT_DELV_DT = to_date('" + txtExtDelvDate.Text + "','dd/mm/yyyy'),USER_ID='" + Session["UName"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'), ITEM_CD='" + item_cd + "', PL_NO='" + txtPLNO.Text.Trim() + "' where CASE_NO = '" + Label2.Text + "' And ITEM_SRNO = " + txtItemSLNo.Text + "", conn1);
				cmd.ExecuteNonQuery();
				OracleCommand cmd1 = new OracleCommand("select count(*) from T18_CALL_DETAILS where CASE_NO = '" + Label2.Text + "' And ITEM_SRNO_PO = " + txtItemSLNo.Text + "", conn1);
				int nos = Convert.ToInt32(cmd1.ExecuteScalar());
				if (nos > 0)
				{
					OracleCommand cmd2 = new OracleCommand("update T18_CAll_DETAILS set ITEM_DESC_PO=upper('" + txtItemDescpt.Text + "'),QTY_ORDERED ='" + txtQty.Text + "',USER_ID='" + Session["UName"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where CASE_NO = '" + Label2.Text + "' And ITEM_SRNO_PO = " + txtItemSLNo.Text + "", conn1);
					cmd2.ExecuteNonQuery();
					OracleCommand cmd3 = new OracleCommand("update T18_CAll_DETAILS T18 set CONSIGNEE_CD=" + ddlConsigneeCD.SelectedValue + " where CASE_NO = '" + Label2.Text + "' And ITEM_SRNO_PO = " + txtItemSLNo.Text + " and 'M'=(select T17_CALL_REGISTER.CALL_STATUS from T17_CALL_REGISTER where T17_CALL_REGISTER.CASE_NO=T18.CASE_NO and T17_CALL_REGISTER.CALL_RECV_DT=T18.CALL_RECV_DT and T17_CALL_REGISTER.CALL_SNO=T18.CALL_SNO)", conn1);
					cmd3.ExecuteNonQuery();

					//DisplayAlert("If Consignee or Item Ordered has modified then the Call Details has also been modified, for the given Case No. and Item Serial No.!!!");		
					DisplayAlert("In Case Bill has been generated,Please update the Bill after making neccessary changes in PO!!!");

					//					OracleCommand cmd3 =new OracleCommand("Select Count(M.BILL_NO) From T23_BILL_ITEMS D,T22_BILL M where D.BILL_NO=M.BILL_NO AND M.CASE_NO = '" + Label2.Text + "' And D.ITEM_SRNO= " + txtItemSLNo.Text,conn1);
					//					int bills=Convert.ToInt32(cmd3.ExecuteScalar());
					//					if(bills>0)
					//					{
					//						OracleCommand cmd4 =new OracleCommand("update T22_BILL set BILL_STATUS='E',USER_ID='"+Session["UName"] +"', DATETIME=to_date('" +ss+ "','dd/mm/yyyy-HH24:MI:SS') where BILL_NO IN (Select M.BILL_NO From T23_BILL_ITEMS D,T22_BILL M where D.BILL_NO=M.BILL_NO AND M.CASE_NO = '" + Label2.Text + "' And D.ITEM_SRNO= " + txtItemSLNo.Text+")",conn1);
					//						cmd4.ExecuteNonQuery();
					//						DisplayAlert("You are requested to regenerate the Bills for this Case No.!!!");		
					//					}



				}


				//				if(lblOldConCD.Text.Equals(ddlConsigneeCD.SelectedValue)==false)
				//				{
				//					//DisplayAlert("Consignee Update Procedure will be Called Here.!!!");		
				//					OracleCommand cmdp=null;
				//					cmdp = new OracleCommand("UPDATE_CONSIGNEE_T15_18_20",conn1);
				//					cmdp.CommandType = CommandType.StoredProcedure;
				//						
				//					OracleParameter prm1 = new OracleParameter("IN_CASE_NO",System.Data.OracleClient.OracleType.VarChar);
				//					prm1.Direction = ParameterDirection.Input;
				//					prm1.Value = Label2.Text;
				//					cmdp.Parameters.Add(prm1);
				//						
				//					OracleParameter prm2 = new OracleParameter("IN_ITEM_SRNO",System.Data.OracleClient.OracleType.Number);
				//					prm2.Direction = ParameterDirection.Input;
				//					prm2.Value = Convert.ToInt32(txtItemSLNo.Text);
				//					cmdp.Parameters.Add(prm2);
				//
				//					OracleParameter prm3 = new OracleParameter("IN_OLD_CONSIGNEE_CD",System.Data.OracleClient.OracleType.Number);
				//					prm3.Direction = ParameterDirection.Input;
				//					prm3.Value = Convert.ToInt32(lblOldConCD.Text);
				//					cmdp.Parameters.Add(prm3);
				//						
				//					OracleParameter prm4 = new OracleParameter("IN_NEW_CONSIGNEE_CD",System.Data.OracleClient.OracleType.Number);
				//					prm4.Direction = ParameterDirection.Input;
				//					prm4.Value = Convert.ToInt32(ddlConsigneeCD.SelectedValue);
				//					cmdp.Parameters.Add(prm4);
				//
				//					OracleParameter prm5 = new OracleParameter("IN_USER_ID",System.Data.OracleClient.OracleType.VarChar);
				//					prm5.Direction = ParameterDirection.Input;
				//					prm5.Value =Session["Uname"].ToString();
				//					cmdp.Parameters.Add(prm5);
				//
				//					OracleParameter prm6 = new OracleParameter("OUT_ERR_CD",System.Data.OracleClient.OracleType.Number,1);
				//					prm6.Direction = ParameterDirection.Output;
				//					cmdp.Parameters.Add(prm6);
				//
				//					cmdp.ExecuteNonQuery();
				//					
				//					if(Convert.ToInt16(cmdp.Parameters["OUT_ERR_CD"].Value)==-1)
				//					{
				//						DisplayAlert("Unable to update the Consignee due to failure of primary key constraint in Inspection Certificate Form. !!!");
				//					}
				//				}

				CsNo = Label2.Text;
				CASE_NO = Label2.Text;
				conn1.Close();
				fillgrid1();
				btnDelete.Visible = false;
				btnSave.Visible = false;
				btnAdd.Visible = true;

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
					OracleCommand cmd = new OracleCommand("delete T15_PO_DETAIL where CASE_NO = '" + Label2.Text + "'And ITEM_SRNO=" + txtItemSLNo.Text + "", conn1);
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
				Response.Redirect(("Error_Form.aspx?err=" + str1));
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
			da = new OracleDataAdapter("Select p.CASE_NO,p.ITEM_SRNO,p.ITEM_DESC,(C.CONSIGNEE_CD||'-'||nvl2(trim(C.CONSIGNEE_DESIG),trim(C.CONSIGNEE_DESIG)||'/','')||nvl2(trim(C.CONSIGNEE_DEPT),trim(C.CONSIGNEE_DEPT)||'/','')||nvl2(trim(C.CONSIGNEE_FIRM),trim(C.CONSIGNEE_FIRM)||'/','')||NVL2(trim(C.CONSIGNEE_ADD1),trim(C.CONSIGNEE_ADD1)||'/','')||NVL2(trim(D.LOCATION),trim(D.LOCATION)||' : '||trim(D.CITY),trim(D.CITY))) CONSIGNEE_NAME,p.QTY,p.RATE,p.VALUE from T15_PO_DETAIL p,T06_CONSIGNEE C,T03_CITY D where p.CONSIGNEE_CD=C.CONSIGNEE_CD AND C.CONSIGNEE_CITY=D.CITY_CD And CASE_NO='" + Label2.Text + "' Order by p.ITEM_SRNO", conn1);//And ITEM_SRNO='" + txtItemSLNo.Text + "'
			DataSet ds = new DataSet();
			da.Fill(ds, "T15_PO_DETAIL");
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
		public void fill_ConsigneeCd()
		{
			try
			{
				ptype = Request.Params["type"].ToString();
				string cno = Request.Params["CASE_NO"].ToString();
				ddlConsigneeCD.Items.Clear();
				DataSet dsP = new DataSet();
				//string str1 = "select CONSIGNEE_CD,CONSIGNEE_S_NAME from T06_CONSIGNEE where CONSIGNEE_TYPE='"+ptype+"' ORDER BY CONSIGNEE_S_NAME"; 
				string str1;

				str1 = "select C.CONSIGNEE_CD,(C.CONSIGNEE_CD||'-'||nvl2(trim(C.CONSIGNEE_DESIG),trim(C.CONSIGNEE_DESIG)||'/','')||nvl2(trim(C.CONSIGNEE_DEPT),trim(C.CONSIGNEE_DEPT)||'/','')||nvl2(trim(C.CONSIGNEE_FIRM),trim(C.CONSIGNEE_FIRM)||'/','')||NVL2(trim(C.CONSIGNEE_ADD1),trim(C.CONSIGNEE_ADD1)||'/','')||NVL2(trim(D.LOCATION),trim(D.LOCATION)||' : '||trim(D.CITY),trim(D.CITY))) CONSIGNEE_NAME from T06_CONSIGNEE C,T14_PO_BPO P,T03_CITY D WHERE P.CONSIGNEE_CD=C.CONSIGNEE_CD and C.CONSIGNEE_CITY=D.CITY_CD and CASE_NO='" + cno + "' ORDER BY CONSIGNEE_DESIG";
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
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}
		}
		void fill_item_CR()
		{
			try
			{
				lstItemDesc.Items.Clear();
				DataSet dsP1 = new DataSet();
				string str3 = "select RAIL_DESC,RAIL_ID from T34_RAIL_PRICE order by RAIL_DESC ";
				OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
				ListItem lst3;
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP1, "Table");
				for (int i = 0; i <= dsP1.Tables[0].Rows.Count - 1; i++)
				{
					lst3 = new ListItem();
					lst3.Text = dsP1.Tables[0].Rows[i]["RAIL_DESC"].ToString();
					lst3.Value = dsP1.Tables[0].Rows[i]["RAIL_ID"].ToString();
					lstItemDesc.Items.Add(lst3);
				}
				conn1.Close();
				ddlUOMCode.SelectedValue = "6";
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}

		}

		void fill_item_rate_CR()
		{
			try
			{
				string str3 = "select NVL(RAIL_PRICE_PER_MT,0)-NVL(PACKING_CHARGE,0) Rate from T35_RAIL_PRICE_DETAILS where RAIL_ID=" + lstItemDesc.SelectedValue + " and (to_date('" + lblPODT.Text.Trim() + "','dd/mm/yyyy') between PRICE_DATE_FR and PRICE_DATE_TO )";
				OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
				conn1.Open();
				double rate_cr = Convert.ToDouble(myOracleCommand.ExecuteScalar());
				if (rate_cr == 0)
				{
					DisplayAlert("The Rate For the Selected Item does not exists in the Database for the given Po Date. So Kindly put the rate manually!!");
				}
				txtRate.Text = Convert.ToString(rate_cr);
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
		// ------------------ Searching And Showing Records From Table ------------------ //
		public void search1()
		{
			conn1.Open();
			try
			{
				OracleCommand cmd = new OracleCommand("select CASE_NO,ITEM_SRNO,ITEM_DESC,CONSIGNEE_CD,QTY,UOM_CD,RATE,BASIC_VALUE,SALES_TAX_PER,SALES_TAX,EXCISE_TYPE,EXCISE_PER,EXCISE,DISCOUNT_TYPE,DISCOUNT_PER,DISCOUNT,OT_CHARGE_TYPE,OT_CHARGE_PER,OTHER_CHARGES,VALUE,to_char(DELV_DT,'dd/mm/yyyy') DELV_DT,to_char(EXT_DELV_DT,'dd/mm/yyyy') EXT_DELV_DT,NVL(ITEM_CD,'X')ITEM_CD, PL_NO from T15_PO_DETAIL where CASE_NO='" + CASE_NO + "' And ITEM_SRNO=" + ITEM_SRNO, conn1);
				OracleDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					Label2.Text = Convert.ToString(reader["CASE_NO"]);
					Label3.Text = Convert.ToString(reader["ITEM_SRNO"]);
					txtItemSLNo.Text = Convert.ToString(reader["ITEM_SRNO"]);
					txtItemDescpt.Text = Convert.ToString(reader["ITEM_DESC"]);
					ddlConsigneeCD.SelectedValue = Convert.ToString(reader["CONSIGNEE_CD"]);
					lblOldConCD.Text = Convert.ToString(reader["CONSIGNEE_CD"]);
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
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}
		}
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Label2.Text = CsNo;
			fill_ConsigneeCd();
			//fill_BPOcd();
			fill_UOM();
			clear1();
			btnSave.Visible = true;
			btnAdd.Visible = false;
			btnDelete.Visible = false;
			getisrno();
			if (Session["Region"].ToString() == "C")
			{
				lstItemDesc.Visible = true;
				fill_item_CR();
				fill_item_rate_CR();
				txtItemDescpt.Text = lstItemDesc.SelectedItem.Text;
			}
			else
			{
				lstItemDesc.Visible = false;
			}

		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			//			clear1();
			//			fill_ConsigneeCd();
			//			fill_BPOcd();
			//			fill_UOM();
			//			btnAdd.Visible=true;
			//			btnCancel.Visible=true;
			//			btnSave.Visible=false;
			//			btnDelete.Visible=false;
			//			Response.Redirect("PurchesOrder1_Form.aspx");
			Response.Redirect("PurchesOrder_Form.aspx?Action=M&case_no=" + Label2.Text.Trim());
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
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}
		}


		void getisrno()
		{
			try
			{
				//string str1 = "select nvl(max(ITEM_SRNO),0)+1  from T15_PO_DETAIL where CASE_NO='"+CsNo+"' and CONSIGNEE_CD="+ddlConsigneeCD.SelectedValue+"" ; 
				string str1 = "select nvl(max(ITEM_SRNO),0)+1  from T15_PO_DETAIL where CASE_NO='" + CsNo + "'";
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
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}
		}
		protected void ddlUOMCode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			getuomfactor();
			rbs.SetFocus(txtRate);

		}

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			string sql = "Select p.CASE_NO,p.ITEM_SRNO,p.ITEM_DESC,(C.CONSIGNEE_CD||'-'||nvl2(trim(C.CONSIGNEE_DESIG),trim(C.CONSIGNEE_DESIG)||'/','')||nvl2(trim(C.CONSIGNEE_DEPT),trim(C.CONSIGNEE_DEPT)||'/','')||nvl2(trim(C.CONSIGNEE_FIRM),trim(C.CONSIGNEE_FIRM)||'/','')||NVL2(trim(C.CONSIGNEE_ADD1),trim(C.CONSIGNEE_ADD1)||'/','')||NVL2(trim(D.LOCATION),trim(D.LOCATION)||' : '||trim(D.CITY),trim(D.CITY))) CONSIGNEE_NAME,p.QTY,p.RATE,p.VALUE from T15_PO_DETAIL p,T06_CONSIGNEE C,T03_CITY D where p.CONSIGNEE_CD=C.CONSIGNEE_CD AND C.CONSIGNEE_CITY=D.CITY_CD And CASE_NO='" + Label2.Text + "' ";
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
			da.Fill(ds, "T15_PO_DETAIL");
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
		}

		protected void lstItemDesc_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fill_item_rate_CR();
			txtItemDescpt.Text = lstItemDesc.SelectedItem.Text;
		}

		protected void txtSaleTaxAmt_TextChanged(object sender, System.EventArgs e)
		{

		}


	}
}