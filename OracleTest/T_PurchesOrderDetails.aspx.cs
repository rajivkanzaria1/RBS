using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.T_PurchesOrderDetails
{
	public partial class T_PurchesOrderDetails : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		public string CASE_NO, ITEM_SRNO, CALL_RECV_DT;
		static string CsNo;
		string CD, ss;
		public string ptype;
		int ecode = 0;

		void fill_ie()
		{
			DataSet dsP1 = new DataSet();
			string str3 = "select IE_CD, IE_NAME from T09_IE where IE_STATUS is null and IE_REGION='" + Session["REGION"] + "' order by IE_NAME ";
			OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
			ListItem lst3;
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP1, "Table");
			for (int i = 0; i <= dsP1.Tables[0].Rows.Count - 1; i++)
			{
				lst3 = new ListItem();
				lst3.Text = dsP1.Tables[0].Rows[i]["IE_NAME"].ToString();
				lst3.Value = dsP1.Tables[0].Rows[i]["IE_CD"].ToString();
				//lstIE.Items.Add(lst3); 
			}
			conn1.Close();

		}
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

				//cas_no1=Request.Params["Cs_No1"].ToString();	

			}
			if (!IsPostBack)
			{
				fill_ConsigneeCd();
				//fill_BPOcd();
				fill_UOM();
				fill_ie();
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
			//btnAdd.Visible=true;
		}
		// ------------------ Saving Record in Table ------------------ //
		public void save()
		{
			conn1.Open();
			try
			{


				OracleCommand cmd2 = new OracleCommand("insert into T15_PO_DETAIL(CASE_NO,ITEM_SRNO,ITEM_DESC,CONSIGNEE_CD,QTY,RATE,UOM_CD,BASIC_VALUE,SALES_TAX_PER,SALES_TAX,EXCISE_PER,EXCISE,VALUE,USER_ID,DATETIME) values('" + Label2.Text + "'," + txtItemSLNo.Text + ",upper('" + txtItemDescpt.Text + "')," + ddlConsigneeCD.SelectedItem.Value + "," + txtQty.Text + "," + txtRate.Text + "," + ddlUOMCode.SelectedItem.Value + "," + txtBaseValue.Text + "," + txtSaleTaxPre.Text + "," + txtSaleTaxAmt.Text + "," + txtExcise.Text + "," + txtExciseAmt.Text + "," + txtValue.Text + ",'" + Session["Uname"] + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))", conn1);
				cmd2.ExecuteNonQuery();

				OracleCommand cmd3 = new OracleCommand("insert into T18_CALL_DETAILS(CASE_NO,CALL_RECV_DT,ITEM_SRNO_PO,ITEM_DESC_PO,CONSIGNEE_CD,QTY_ORDERED,CUM_QTY_PREV_OFFERED,CUM_QTY_PREV_PASSED,QTY_TO_INSP,QTY_PASSED,QTY_REJECTED,QTY_DUE,USER_ID,DATETIME) values('" + Label2.Text + "',to_date('" + ss + "','dd/mm/yyyy')," + txtItemSLNo.Text + ",upper('" + txtItemDescpt.Text + "')," + ddlConsigneeCD.SelectedItem.Value + "," + txtQOrd.Text + "," + txtCQty.Text + "," + txtQPrePassed.Text + "," + txtQuanInsp.Text + "," + txtQPass.Text + "," + txtQRej.Text + "," + txtQDue.Text + ",'" + Session["Uname"] + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))", conn1);
				cmd3.ExecuteNonQuery();

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
				OracleCommand cmd4 = new OracleCommand("update T15_PO_DETAIL set ITEM_DESC =upper('" + txtItemDescpt.Text + "'),CONSIGNEE_CD ='" + ddlConsigneeCD.SelectedItem.Value + "',QTY ='" + txtQty.Text + "',UOM_CD ='" + ddlUOMCode.SelectedItem.Value + "',BASIC_VALUE= '" + txtBaseValue.Text + "',RATE='" + txtRate.Text + "', EXCISE_PER = '" + txtExcise.Text + "',EXCISE ='" + txtExciseAmt.Text + "', SALES_TAX_PER ='" + txtSaleTaxPre.Text + "', SALES_TAX ='" + txtSaleTaxAmt.Text + "',VALUE = '" + txtValue.Text + "',USER_ID='" + Session["UName"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where CASE_NO = '" + Label2.Text + "' And ITEM_SRNO = " + txtItemSLNo.Text + "", conn1);
				cmd4.ExecuteNonQuery();

				OracleCommand cmd3 = new OracleCommand("update T18_CALL_DETAILS set ITEM_DESC_PO=upper('" + txtItemDescpt.Text + "'),CONSIGNEE_CD=" + ddlConsigneeCD.SelectedItem.Value + ",QTY_ORDERED=" + txtQOrd.Text + ",CUM_QTY_PREV_OFFERED=" + txtCQty.Text + ",CUM_QTY_PREV_PASSED=" + txtQPrePassed.Text + ",QTY_TO_INSP=" + txtQuanInsp.Text + ",QTY_PASSED=" + txtQPass.Text + ",QTY_REJECTED=" + txtQRej.Text + ",QTY_DUE=" + txtQDue.Text + ",USER_ID='" + Session["Uname"] + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where CASE_NO='" + Label2.Text + "' AND CALL_RECV_DT=to_date('" + ss + "','dd/mm/yyyy') AND ITEM_SRNO_PO = " + txtItemSLNo.Text + "", conn1);
				cmd3.ExecuteNonQuery();

				CsNo = Label2.Text;
				CASE_NO = Label2.Text;
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
				OracleCommand cmd = new OracleCommand("delete T15_PO_DETAIL where CASE_NO = '" + Label2.Text + "'And ITEM_SRNO='" + txtItemSLNo.Text + "'", conn1);
				cmd.ExecuteNonQuery();
				Label2.Text = CsNo;
				CASE_NO = Label2.Text;
				btnSave.Visible = false;
				btnAdd.Visible = true;
				btnDelete.Visible = false;
				btnCancel.Visible = true;
				clear1();
				fillgrid1();
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
			da = new OracleDataAdapter("Select p.CASE_NO,p.ITEM_SRNO,p.ITEM_DESC,(trim(c.CONSIGNEE_DESIG)||'/'||trim(c.CONSIGNEE_DEPT)||'/'||trim(c.CONSIGNEE_FIRM)||'/'||D.CITY) CONSIGNEE_NAME,p.QTY,p.BASIC_VALUE,p.VALUE from T15_PO_DETAIL p,T06_CONSIGNEE c,T03_CITY D where p.CONSIGNEE_CD=c.CONSIGNEE_CD AND c.CONSIGNEE_CITY=D.CITY_CD And CASE_NO='" + Label2.Text + "'", conn1);//And ITEM_SRNO='" + txtItemSLNo.Text + "'
			DataSet ds = new DataSet();
			da.Fill(ds, "T15_PO_DETAIL");
			DgPO.DataSource = ds;
			DgPO.DataBind();
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

				str1 = "select C.CONSIGNEE_CD,(trim(C.CONSIGNEE_DESIG)||'/'||trim(C.CONSIGNEE_DEPT)||'/'||trim(C.CONSIGNEE_FIRM)) CONSIGNEE_NAME from T06_CONSIGNEE C,T14_PO_BPO P WHERE P.CONSIGNEE_CD=C.CONSIGNEE_CD and CASE_NO='" + cno + "' ORDER BY CONSIGNEE_DESIG";
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
		//		public void fill_BPOcd()
		//		{
		//			
		//			try
		//			{
		//				ptype= Request.Params["type"].ToString();
		//				ddlBPOCode.Items.Clear();
		//				DataSet dsP = new DataSet();
		//				string str1;
		//				if(ptype!="P" && ptype!="F" && ptype!="U" && ptype!="S")
		//				{
		//					str1 = "select BPO_CD,(BPO_NAME||'/'||BPO_ADD||'/'||BPO_RLY) BPO_NAME from T12_BILL_PAYING_OFFICER where BPO_RLY='"+ptype+"' ORDER BY BPO_NAME"; 
		//				}
		//				else
		//				{
		//					str1 = "select BPO_CD,(BPO_NAME||'/'||BPO_ADD||'/'||BPO_RLY) BPO_NAME from T12_BILL_PAYING_OFFICER where BPO_TYPE='"+ptype+"' ORDER BY BPO_NAME"; 
		//				}
		//				OracleDataAdapter da = new OracleDataAdapter(str1, conn1); 
		//				OracleCommand myOracleCommand = new OracleCommand(str1, conn1); 
		//				ListItem lst; 
		//				da.SelectCommand = myOracleCommand; 
		//				da.Fill(dsP, "Table"); 
		//			for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++) 
		//			{ 
		//				lst = new ListItem(); 
		//				lst.Text = dsP.Tables[0].Rows[i]["BPO_NAME"].ToString(); 
		//				lst.Value = dsP.Tables[0].Rows[i]["BPO_CD"].ToString();
		//				ddlBPOCode.Items.Add(lst); 
		//			} 
		//			}
		//			catch(Exception ex)
		//			{
		//				string str;
		//				str = ex.Message;
		//				string str1=str.Replace("\n","");
		//				Response.Redirect(("Error_Form.aspx?err=" + str1));
		//			}
		//		}
		public void fill_UOM()
		{
			try
			{
				ddlUOMCode.Items.Clear();
				DataSet dsP = new DataSet();
				string str1 = "select UOM_CD,UOM_S_DESC from T04_UOM ORDER BY UOM_S_DESC";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				ListItem lst;
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					lst = new ListItem();
					lst.Text = dsP.Tables[0].Rows[i]["UOM_S_DESC"].ToString();
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
		// ------------------ Searching And Showing Records From Table ------------------ //
		public void search1()
		{
			conn1.Open();
			try
			{
				OracleCommand cmd = new OracleCommand("select CASE_NO,ITEM_SRNO,ITEM_DESC,CONSIGNEE_CD,QTY,UOM_CD,RATE,BASIC_VALUE,SALES_TAX_PER,SALES_TAX,EXCISE_PER,EXCISE,DISCOUNT_PER,DISCOUNT,OTHER_CHARGES,VALUE,MANUFACTURE_PLACE,to_char(DELV_DT,'dd/mm/yyyy') DELV_DT,to_char(EXT_DELV_DT,'dd/mm/yyyy') EXT_DELV_DT from T15_PO_DETAIL where CASE_NO='" + CASE_NO + "' And ITEM_SRNO=" + ITEM_SRNO, conn1);
				OracleDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					Label2.Text = Convert.ToString(reader["CASE_NO"]);
					Label3.Text = Convert.ToString(reader["ITEM_SRNO"]);
					txtItemSLNo.Text = Convert.ToString(reader["ITEM_SRNO"]);
					txtItemDescpt.Text = Convert.ToString(reader["ITEM_DESC"]);
					ddlConsigneeCD.SelectedValue = Convert.ToString(reader["CONSIGNEE_CD"]);
					txtQty.Text = Convert.ToString(reader["QTY"]);
					txtBaseValue.Text = Convert.ToString(reader["BASIC_VALUE"]);
					txtRate.Text = Convert.ToString(reader["RATE"]);
					ddlUOMCode.SelectedValue = Convert.ToString(reader["UOM_CD"]);
					txtSaleTaxPre.Text = Convert.ToString(reader["EXCISE_PER"]);
					txtSaleTaxAmt.Text = Convert.ToString(reader["SALES_TAX"]);
					txtExcise.Text = Convert.ToString(reader["EXCISE_PER"]);
					txtExciseAmt.Text = Convert.ToString(reader["EXCISE"]);
					txtValue.Text = Convert.ToString(reader["VALUE"]);
					//ddlBPOCode.SelectedValue = Convert.ToString(reader["BPO_CD"]);

				}
				fillgrid1();
				btnAdd.Visible = true;
				btnSave.Visible = true;
				btnDelete.Visible = true;
				reader.Close();
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
			Response.Redirect("PurchesOrder1_Form.aspx");
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
			txtValue.Text = "";

			//btnAdd.Visible=true;
		}


		void getuomfactor()
		{
			try
			{
				string str1 = "select UOM_FACTOR from T04_UOM where UOM_CD=" + ddlUOMCode.SelectedValue;
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				int factor = Convert.ToInt32(myOracleCommand.ExecuteScalar());
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

		}

		protected void btnCReg_Click(object sender, System.EventArgs e)
		{

			conn1.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
			ss = Convert.ToString(cmd2.ExecuteScalar());
			//OracleCommand cmd1 =new OracleCommand ("insert into T17_CALL_REGISTER(CASE_NO,CALL_RECV_DT,IE_CD,MFG_NAME,USER_ID,DATETIME) values ('" + Label2.Text + "',to_date('" +ss+ "','dd/mm/yyyy'),"+lstIE.SelectedValue+",'" + txtMName.Text + "','"+Session["Uname"]+"', to_date('" +ss+ "','dd/mm/yyyy-HH24:MI:SS'))",conn1);	
			//cmd1.ExecuteNonQuery(); 
			conn1.Close();

		}

		int fill_manufacturer(string vend)
		{
			//ddlManufac.Items.Clear();
			DataSet dsP = new DataSet();
			string str1 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME,VEND_ADD1,VEND_CONTACT_PER_1,VEND_CONTACT_TEL_1 from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and (trim(upper(VEND_CD))=upper('" + vend.Trim() + "') or trim(upper(VEND_NAME)) LIKE upper('" + vend.Trim() + "%')) and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME";
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
					//ddlManufac.Items.Add(lst); 
				}
				//ddlManufac.Visible=true;
				//ddlManufac.SelectedIndex=0;
				ecode = 2;
				return (ecode);

			}

		}

		private void btnFCList_Click(object sender, System.EventArgs e)
		{
			//ddlManufac.Visible=true;

			try
			{
				//				int a =fill_manufacturer(txtMName.Text);
				//				if (a==1)
				//				{
				//					//ddlManufac.Visible=false;
				//					DisplayAlert("No Manufacturer Found!!!");
				//				}
				//				else if(a==2)
				//				{					
				//					//txtMName.Text=ddlManufac.SelectedValue;
				//					conn1.Close();
				//				}




			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str2 = str.Replace("\n", "");
				Response.Redirect("Error_Form.aspx?err=" + str2);

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

		private void ddlManufac_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//txtMName.Text=ddlManufac.SelectedValue;
			conn1.Close();

		}
	}
}