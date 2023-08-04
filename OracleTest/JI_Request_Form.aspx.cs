using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.JI_Request_Form
{
	public partial class JI_Request_Form : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtPONo;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtPODate;
		protected System.Web.UI.WebControls.Button btnSearchPO;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Label lblSearchStatus;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblCaseNo;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblBkNo;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label lblSetNo;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label lblIE;
		protected System.Web.UI.WebControls.Label lblIECd;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label lblPoNo;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label lblRly;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label lblConsignee;
		protected System.Web.UI.WebControls.Label lblConsigneeCd;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.Label lblVendor;
		protected System.Web.UI.WebControls.Label lblVendorCd;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.Label lblIcDate;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox txtMemoNo;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.TextBox txtMemoDt;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label lblItemDesc;
		protected System.Web.UI.WebControls.DropDownList lstPoItems;
		protected System.Web.UI.WebControls.Label lblItemSrnoPo;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.TextBox txtQtyOffered;
		protected System.Web.UI.WebControls.Label Label26;
		protected System.Web.UI.WebControls.TextBox txtQtyRej;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.Label lblUOMDesc;
		protected System.Web.UI.WebControls.Label lblUOM;
		protected System.Web.UI.WebControls.Label Label27;
		protected System.Web.UI.WebControls.Label lblRate;
		protected System.Web.UI.WebControls.Label lblUomRate;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.TextBox txtValueRej;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.TextBox txtRejReason;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.Label lblIcNo;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.Label Label23;
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.Label Label28;
		protected System.Web.UI.WebControls.TextBox txtDept;
		protected System.Web.UI.WebControls.TextBox txtMobile;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.Label Label24;
		protected System.Web.UI.HtmlControls.HtmlInputFile File1;
		protected Tittle.Controls.CustomDataGrid DgCompCaseSearch;
		protected System.Web.UI.WebControls.Panel Panel_1;
		protected System.Web.UI.WebControls.Panel Panel_2;
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!(IsPostBack))
			{
				if ((Convert.ToString(Request.Params["CASE_NO"]) != null) & (Convert.ToString(Request.Params["BK_NO"]) != null) & (Convert.ToString(Request.Params["SET_NO"]) != null))
				{
					lblCaseNo.Text = Convert.ToString(Request.Params["CASE_NO"].Trim());
					lblBkNo.Text = Convert.ToString(Request.Params["BK_NO"].Trim());
					lblSetNo.Text = Convert.ToString(Request.Params["SET_NO"].Trim());
					FindIE();
					fill_lstPoItems();
					Panel_2.Visible = true;
					Panel_1.Visible = false;

					//				
					//					string wRegion=Convert.ToString(Session["REGION"]);
					//					if (wRegion=="N") {lblRegion.Text="Northern Region";}
					//					else if (wRegion=="E") {lblRegion.Text="Eastern Region";}
					//					else if (wRegion=="W") {lblRegion.Text="Western Region";}
					//					else if (wRegion=="S") {lblRegion.Text="Southern Region";}
					//					else if (wRegion=="C") {lblRegion.Text="Central Region";}
					//					else {lblRegion.Text="";}
					//					lblCompRecvRgn.Text=wRegion;

				}
				else
				{
					Panel_1.Visible = true;
                    Panel_2.Visible = false;
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
			this.btnSearchPO.Click += new System.EventHandler(this.btnSearchPO_Click);
			this.lstPoItems.SelectedIndexChanged += new System.EventHandler(this.lstPoItems_SelectedIndexChanged);
			this.txtQtyRej.TextChanged += new System.EventHandler(this.txtQtyRej_TextChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void fill_lstPoItems()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			lstPoItems.Items.Clear();
			DataSet ds = new DataSet();
			string MySql = "Select t18.ITEM_SRNO_PO,t18.ITEM_DESC_PO From T18_CALL_DETAILS t18,T20_IC t20 " +
				"Where t18.CASE_NO=t20.CASE_NO and t18.CALL_RECV_DT=t20.CALL_RECV_DT and t18.CALL_SNO=t20.CALL_SNO and t18.CONSIGNEE_CD=t20.CONSIGNEE_CD and " +
				"t20.CASE_NO='" + lblCaseNo.Text + "' and t20.BK_NO='" + lblBkNo.Text + "' and t20.SET_NO='" + lblSetNo.Text + "'";
			OracleCommand cmd = new OracleCommand(MySql, conn1);
			OracleDataAdapter da = new OracleDataAdapter(cmd);
			ListItem lst;
			//
			lst = new ListItem();
			lst.Value = null;
			lst.Text = null;
			lstPoItems.Items.Add(lst);
			//
			da.SelectCommand = cmd;
			da.Fill(ds, "Table");
			for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
			{
				lst = new ListItem();
				lst.Value = ds.Tables[0].Rows[i]["ITEM_SRNO_PO"].ToString();
				lst.Text = ds.Tables[0].Rows[i]["ITEM_DESC_PO"].ToString();
				lstPoItems.Items.Add(lst);
			}
			conn1.Close();
			conn1.Dispose();
			lstPoItems.SelectedValue = lblItemSrnoPo.Text;
		}
		private void FindIE()
		{
			lblIE.Text = "";
			lblPoNo.Text = "";
			lblRly.Text = "";
			lblConsignee.Text = "";
			lblIECd.Text = "";
			lblConsigneeCd.Text = "";
			if (lblCaseNo.Text.Trim() == "" || lblBkNo.Text.Trim() == "" || lblSetNo.Text.Trim() == "") { }
			else
			{
				//Populate PO NO,PO Date, Railway,IE Name and Consignee//
				string MySql = "Select t09.IE_CD, t09.IE_NAME,trim(t13.PO_NO)||' dated- '||to_char(t13.PO_DT,'dd/mm/yyyy') PO,t13.RLY_CD,t20.CONSIGNEE_CD,to_char(t20.IC_DT,'dd/mm/yyyy') IC_DT,v06.CONSIGNEE,t13.VEND_CD,v05.VENDOR " +
					"From T09_IE t09,T13_PO_MASTER t13,T20_IC t20,V06_CONSIGNEE v06,V05_VENDOR v05 " +
					"Where t20.CASE_NO='" + lblCaseNo.Text + "' and t20.BK_NO='" + lblBkNo.Text + "' and t20.SET_NO='" + lblSetNo.Text + "' " +
					"and t20.IE_CD=t09.IE_CD and t13.CASE_NO=t20.CASE_NO and t13.VEND_CD=v05.VEND_CD and t20.CONSIGNEE_CD=v06.CONSIGNEE_CD";
				try
				{
					conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
					OracleCommand cmd = new OracleCommand(MySql, conn1);
					conn1.Open();
					OracleDataReader MyReader = cmd.ExecuteReader();
					while (MyReader.Read())
					{
						lblIE.Text = MyReader["IE_NAME"].ToString();
						lblPoNo.Text = MyReader["PO"].ToString();
						lblRly.Text = MyReader["RLY_CD"].ToString();
						lblConsignee.Text = MyReader["CONSIGNEE"].ToString();
						lblVendor.Text = MyReader["VENDOR"].ToString();
						lblIECd.Text = MyReader["IE_CD"].ToString();
						lblConsigneeCd.Text = MyReader["CONSIGNEE_CD"].ToString();
						lblVendorCd.Text = MyReader["VEND_CD"].ToString();
						lblIcDate.Text = MyReader["IC_DT"].ToString();
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
					conn1.Dispose();
				}
			}
		}
		private void btnSearchPO_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string str1 = "";

				str1 = "select m.CASE_NO,m.PO_NO,to_char(m.PO_DT,'dd/mm/yyyy')PO_DT,(decode(m.RLY_NONRLY,'R','Railway','P','Private','S','State Government','F','Foreign Railways','U','PSU')||'('||m.RLY_CD||')')RLY_CD,(v.VEND_NAME||'('||NVL2(t.LOCATION,t.LOCATION||' : '||t.CITY,t.CITY)||')')VEND_NAME,c.CONSIGNEE, i.BK_NO, i.SET_NO,i.IC_NO, to_char(i.IC_DT,'dd/mm/yyyy') IC_DT from T13_PO_MASTER m,T05_VENDOR v,V06_CONSIGNEE c, T03_CITY t, T20_IC i where m.VEND_CD=v.VEND_CD and v.VEND_CITY_CD=t.CITY_CD And i.CONSIGNEE_CD=c.CONSIGNEE_CD(+) and m.CASE_NO=i.CASE_NO and upper(trim(PO_NO)) LIKE upper(trim('%" + txtPONo.Text.Trim() + "%')) and PO_DT=to_date('" + txtPODate.Text.Trim() + "','dd/mm/yyyy')";



				string str2 = str1 + " ORDER BY CASE_NO ASC";

				OracleDataAdapter da1 = new OracleDataAdapter(str2, conn1);
				DataSet dsP1 = new DataSet();
				OracleCommand myOracleCommand1 = new OracleCommand(str2, conn1);
				conn1.Open();
				da1.SelectCommand = myOracleCommand1;
				da1.Fill(dsP1, "Table");
				if (dsP1.Tables[0].Rows.Count == 0)
				{
					DgCompCaseSearch.Visible = false;
					Panel_1.Visible = false;
					DisplayAlert("No Data Found!!!");

				}
				else
				{
					Panel_1.Visible = true;
					DgCompCaseSearch.DataSource = dsP1;
					DgCompCaseSearch.DataBind();
					DgCompCaseSearch.Visible = true;


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
				conn1.Dispose();
			}
		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		private void lstPoItems_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lblItemDesc.Text = lstPoItems.SelectedItem.Text;
			lblItemSrnoPo.Text = lstPoItems.SelectedValue;
			try
			{
				string MySql = "Select t15.UOM_CD,round(t15.VALUE/t15.QTY,4)RATE,t04.UOM_S_DESC From T15_PO_DETAIL t15,T04_UOM t04 Where t15.UOM_CD=t04.UOM_CD and t15.CASE_NO='" + lblCaseNo.Text + "' and t15.ITEM_SRNO=" + lblItemSrnoPo.Text;
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				conn1.Open();
				OracleCommand cmd = new OracleCommand(MySql, conn1);
				OracleDataReader MyReader = cmd.ExecuteReader();
				while (MyReader.Read())
				{
					lblUOM.Text = MyReader["UOM_CD"].ToString();
					lblUOMDesc.Text = MyReader["UOM_S_DESC"].ToString();
					lblRate.Text = MyReader["RATE"].ToString();
					lblUomRate.Text = " per " + lblUOMDesc.Text;
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
				conn1.Dispose();
			}
			rbs.SetFocus(txtQtyOffered);
		}

		private void txtQtyRej_TextChanged(object sender, System.EventArgs e)
		{
			txtValueRej.Text = Convert.ToString((Convert.ToDecimal(lblRate.Text) * Convert.ToDecimal(txtQtyRej.Text)));
			rbs.SetFocus(txtRejReason);
		}
	}
}