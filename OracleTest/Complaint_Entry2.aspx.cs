using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Complaint_Entry2
{
	public class Complaint_Entry : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblRegion;
		protected System.Web.UI.WebControls.Label lblCompRecvRgn;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.TextBox txtComplaintDt;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox txtMemoNo;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.TextBox txtMemoDt;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.TextBox txtIDESC;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.TextBox txtRejReason;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.DropDownList lstJIRequired;
		protected System.Web.UI.WebControls.Label Label24;
		protected System.Web.UI.WebControls.TextBox txtRemarks;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Label lblIECd;
		protected System.Web.UI.WebControls.Label lblVendorCd;
		protected System.Web.UI.WebControls.Label lblConsigneeCd;
		protected System.Web.UI.WebControls.DropDownList lstConsignee;
		protected System.Web.UI.WebControls.Button btnSCon;
		protected System.Web.UI.WebControls.DropDownList ddlVender;
		protected System.Web.UI.WebControls.TextBox txtVend;
		protected System.Web.UI.WebControls.Button btnFCList;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.TextBox txtSCon;
		protected System.Web.UI.WebControls.DropDownList lstIE;
		protected System.Web.UI.WebControls.Label lblComplaintId;
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		DataSet dsP = new DataSet();
		int ecode;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!(IsPostBack))
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
					lstIE.Items.Add(lst3);
				}
				lstIE.Items.Insert(0, "");
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
			this.btnSCon.Click += new System.EventHandler(this.btnSCon_Click);
			this.btnFCList.Click += new System.EventHandler(this.btnFCList_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		private void btnSCon_Click(object sender, System.EventArgs e)
		{
			lstConsignee.Items.Clear();
			DataSet dsP = new DataSet();
			string str1 = "Select CONSIGNEE_CD, (CONSIGNEE_CD||'-'||CONSIGNEE) CONSIGNEE from V06_CONSIGNEE where upper(trim(CONSIGNEE)) like trim(upper('" + txtSCon.Text.Trim() + "%')) order by V06_CONSIGNEE.CONSIGNEE";
			OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			ListItem lst;
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			if (dsP.Tables[0].Rows.Count == 0)
			{
				DisplayAlert("No Consignee Found!!!");
				//ddlConsigneeCD.Visible=false;
			}
			else
			{
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					lst = new ListItem();
					lst.Text = dsP.Tables[0].Rows[i]["CONSIGNEE"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["CONSIGNEE_CD"].ToString();
					lstConsignee.Items.Add(lst);
				}
				lstConsignee.Visible = true;
				lstConsignee.SelectedIndex = 0;
				txtSCon.Text = lstConsignee.SelectedValue;
				//rbs.SetFocus(ddlVender);
			}
		}
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
				txtVend.Text = ddlVender.SelectedValue;
				//rbs.SetFocus(ddlVender);
				ecode = 2;
				return (ecode);

			}
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

	}
}