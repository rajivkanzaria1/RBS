using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.IE_Marked_To_Vendor
{
	public partial class IE_Marked_To_Vendor : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.DropDownList ddlVender;
		protected System.Web.UI.WebControls.Button btnFCList;
		protected System.Web.UI.WebControls.TextBox txtVend;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList lstIE;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtDtFr;
		protected System.Web.UI.WebControls.Button btnSearch;
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected Tittle.Controls.CustomDataGrid DgIEV1;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Button btnCancel;
		int ecode = 0;
		string VEND_CD, SNO, ACTION, IE_DEPT, IE_CD;
		protected System.Web.UI.WebControls.Label lblREPIE;
		protected System.Web.UI.WebControls.Label lblREBDTFR;
		protected System.Web.UI.WebControls.Label lblHeading;
		protected System.Web.UI.WebControls.Panel Panel_2;
		protected System.Web.UI.WebControls.Label lblNoRecFound;
		protected System.Web.UI.WebControls.Panel Panel_1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnFCList.Attributes.Add("OnClick", "JavaScript:validate1();");

			if (Convert.ToString(Request.Params["VEND_CD"]) == null && Convert.ToString(Request.Params["SNO"]) == null)
			{
				VEND_CD = "";
				SNO = "";
				IE_CD = "";
				IE_DEPT = "";
				ACTION = "";
				Panel_1.Visible = false;
				Panel_2.Visible = false;
				ddlVender.Visible = false;
				btnSearch.Visible = false;
				btnAdd.Visible = false;
			}
			else
			{
				VEND_CD = Convert.ToString(Request.Params["VEND_CD"].Trim());
				if (Convert.ToString(Request.Params["SNO"]) == null)
				{
					SNO = "";
					IE_CD = "";
					IE_DEPT = "";
					ACTION = "A";
					lblHeading.Text = "Add IE";
					Panel_2.Visible = false;
				}
				else
				{
					SNO = Convert.ToString(Request.Params["SNO"].Trim());
					IE_CD = Convert.ToString(Request.Params["IE_CD"]);
					IE_DEPT = Convert.ToString(Request.Params["IE_DEPT"]);
					ACTION = "R";
					lblHeading.Text = "Replace IE";
					lblREPIE.Text = "IE To Be Replaced: " + Convert.ToString(Request.Params["IE_NAME"]);
					lblREBDTFR.Text = "From Date: " + Convert.ToString(Request.Params["DT_FR"]);
					Panel_2.Visible = true;
				}
				Panel_1.Visible = true;
				lblHeading.Visible = true;
				txtVend.Text = VEND_CD;
				int a = fill_vendor("select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and trim(VEND_CD)=" + txtVend.Text.Trim() + " and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME");
				fillgrid();
				rbs.SetFocus(lstIE);
				if (Convert.ToString(Session["Role"]) != "Administrator")
				{
					btnSave.Enabled = false;
				}
			}
			if (!(IsPostBack))
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
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
				conn1.Close();
				lstIE.Items.Insert(0, "");
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
			this.btnFCList.Click += new System.EventHandler(this.btnFCList_Click);
			this.ddlVender.SelectedIndexChanged += new System.EventHandler(this.ddlVender_SelectedIndexChanged);
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.DgIEV1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DgIEV1_ItemDataBound);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

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
						btnSearch.Visible = true;
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
						btnSearch.Visible = true;

					}
				}
				else
				{
					string str2 = str.Replace("\n", "");
					Response.Redirect("Error_Form.aspx?err=" + str2);
				}

			}

		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		int fill_vendor(string str1)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
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

		void vendor_status(String ven)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string vend;
				conn1.Open();
				string s = "select VEND_STATUS,to_char(VEND_STATUS_DT_FR,'dd/mm/yyyy')VEND_STATUS_FR,to_char(VEND_STATUS_DT_TO,'dd/mm/yyyy')VEND_STATUS_TO from T05_VENDOR where  VEND_CD='" + ddlVender.SelectedValue + "'";
				OracleCommand cmd = new OracleCommand(s, conn1);
				OracleDataReader dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					vend = Convert.ToString(dr["VEND_STATUS"]);
					if (vend == "B")
					{
						DisplayAlert("Selected Vendor is Banned/Blacklisted From  " + Convert.ToString(dr["VEND_STATUS_FR"]) + " To " + Convert.ToString(dr["VEND_STATUS_TO"]));
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
				conn1.Dispose();
			}
		}

		private void ddlVender_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			vendor_status(ddlVender.SelectedValue);

		}

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			fillgrid();
		}
		void fillgrid()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			OracleDataAdapter da1 = null;
			try
			{
				string str1 = "select T09.IE_NAME,DECODE(T09.IE_DEPARTMENT,'M','Mechanical','E','Electrical','C','Civil','L','Metallurgy','T','Textiles','P','Power Engineering') IE_DEPT,T09.IE_DEPARTMENT,T37.IE_CD,T37.VEND_CD, T37.SNO, TO_CHAR(T37.DATE_FR,'DD/MM/YYYY')DATE_FR, NVL(TO_CHAR(T37.DATE_TO,'DD/MM/YYYY'),'-')DATE_TO from T37_VENDOR_IE T37, T09_IE T09 where T37.IE_CD=T09.IE_CD and VEND_CD='" + ddlVender.SelectedItem.Value + "' order by SNO ";
				da1 = new OracleDataAdapter(str1, conn1);
				DataSet dsP1 = new DataSet();
				OracleCommand myOracleCommand1 = new OracleCommand(str1, conn1);
				conn1.Open();
				da1.SelectCommand = myOracleCommand1;
				da1.Fill(dsP1, "Table");

				if (dsP1.Tables[0].Rows.Count == 0)
				{
					DgIEV1.Visible = false;
					DgIEV1.Visible = false;
					lblNoRecFound.Visible = true;

				}
				else
				{
					DgIEV1.DataSource = dsP1;
					DgIEV1.DataBind();
					DgIEV1.Visible = true;
					lblNoRecFound.Visible = false;
				}
				btnAdd.Visible = true;
				conn1.Close();
				if (Convert.ToString(Session["Role"]) != "Administrator")
				{
					DgIEV1.Columns[5].Visible = false;
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
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				conn1.Open();
				OracleCommand cmd1 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH:MI:SS') from dual", conn1);
				string ss = Convert.ToString(cmd1.ExecuteScalar());

				OracleCommand cmd3 = new OracleCommand("Select IE_DEPARTMENT from T09_IE where IE_CD=" + lstIE.SelectedItem.Value, conn1);
				string ie_desc = Convert.ToString(cmd3.ExecuteScalar());
				conn1.Close();

				if (ACTION == "A")
				{
					conn1.Open();
					string s = "select T37.IE_CD from T37_VENDOR_IE T37, T09_IE T09 where T37.IE_CD=T09.IE_CD and T09.IE_DEPARTMENT='" + ie_desc + "' and T37.VEND_CD='" + ddlVender.SelectedValue + "'";
					OracleCommand cmd = new OracleCommand(s, conn1);
					string dr = Convert.ToString(cmd.ExecuteScalar());
					if (dr != "")
					{
						DisplayAlert("IE ALREADY EXIST OF THE GIVEN DESCIPLINE, CLICK [REPLACE] TO CHANGE THE IE OF SIMILAR DESCIPLINE OR [ADD NEW IE] TO SELECT AN IE OF OTHER DESCIPLINE!!!");
					}
					else
					{

						OracleCommand cmd2 = new OracleCommand("Select NVL(max(SNO),0) from T37_VENDOR_IE where VEND_CD=" + ddlVender.SelectedItem.Value, conn1);
						int s_no = Convert.ToInt16(cmd2.ExecuteScalar()) + 1;
						string myInsertQuery = "INSERT INTO T37_VENDOR_IE(VEND_CD, IE_CD, SNO, DATE_FR, DATE_TO, USER_ID, DATETIME) values(" + ddlVender.SelectedItem.Value + ", " + lstIE.SelectedItem.Value + "," + s_no + " ,to_date('" + txtDtFr.Text.Trim() + "','dd/mm/yyyy'),null,'" + Session["Uname"] + "', to_date('" + ss + "','dd/mm/yyyy-HH:MI:SS'))";
						OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
						myInsertCommand.Connection = conn1;
						myInsertCommand.ExecuteNonQuery();

						DisplayAlert("Your Record Has Been Saved!!!");
					}
					conn1.Close();
				}
				else if (ACTION == "R")
				{
					string chk = "";
					string msg = "";
					if (IE_CD == lstIE.SelectedItem.Value)
					{
						msg = "SELECT DIFFERENT IE OF SAME DESCIPLINE!!!";
						chk = "1";
					}
					else if (dtcomp(lblREBDTFR.Text, txtDtFr.Text.Trim()) <= 0)
					{
						msg = "NEW IE [FROM DATE] SHOULD BE GREATER THEN THE [FROM DATE] OF THE IE TO BE REPLACED!!!";
						chk = "1";
					}
					else if (ie_desc == IE_DEPT)
					{
						conn1.Open();
						OracleCommand cmd4 = new OracleCommand("Select T37.IE_CD from T37_VENDOR_IE T37, T09_IE T09 where T37.IE_CD=T09.IE_CD and T37.IE_CD<>" + IE_CD + " and NVL(to_char(DATE_TO,'dd/mm/yyyy'),'X')='X' and T09.IE_DEPARTMENT='" + ie_desc + "' and VEND_CD=" + VEND_CD, conn1);
						chk = Convert.ToString(cmd4.ExecuteScalar());
						conn1.Close();
						if (chk != "")
						{
							msg = "IE OF SAME DESCIPLINE ALREADY EXISTS!!!";
						}
					}
					else if (ie_desc != IE_DEPT)
					{
						msg = "SELECT IE OF SAME DISCIPLINE THAT YOU ARE REPLACING!!!";
						chk = "1";
					}

					if (chk != "")
					{
						DisplayAlert(msg);
					}
					else
					{
						conn1.Open();

						string myUpdateQuery = "Update T37_VENDOR_IE set DATE_TO=to_date('" + txtDtFr.Text + "','dd/mm/yyyy')-1, USER_ID='" + Session["Uname"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH:MI:SS') where VEND_CD=" + VEND_CD + " and IE_CD=" + IE_CD + " AND SNO=" + SNO;
						OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
						myUpdateCommand.Connection = conn1;
						myUpdateCommand.ExecuteNonQuery();

						OracleCommand cmd2 = new OracleCommand("Select NVL(max(SNO),0) from T37_VENDOR_IE where VEND_CD=" + ddlVender.SelectedItem.Value, conn1);
						int s_no = Convert.ToInt16(cmd2.ExecuteScalar()) + 1;
						string myInsertQuery = "INSERT INTO T37_VENDOR_IE(VEND_CD, IE_CD, SNO, DATE_FR, DATE_TO, USER_ID, DATETIME) values(" + ddlVender.SelectedItem.Value + ", " + lstIE.SelectedItem.Value + "," + s_no + " ,to_date('" + txtDtFr.Text.Trim() + "','dd/mm/yyyy'),null,'" + Session["Uname"] + "', to_date('" + ss + "','dd/mm/yyyy-HH:MI:SS'))";
						OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
						myInsertCommand.Connection = conn1;
						myInsertCommand.ExecuteNonQuery();
						conn1.Close();
						lstIE.SelectedIndex = 0;
						txtDtFr.Text = "";
						Panel_1.Visible = false;
						Panel_2.Visible = false;
						lblHeading.Visible = false;
						DisplayAlert("Your Record Has Been Saved!!!");
					}
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
			fillgrid();

		}
		int dtcomp(string dt1, string dt2)
		{
			string myYear, myMonth, myDay;
			myYear = dt1.Substring(17, 4);
			myMonth = dt1.Substring(14, 2);
			myDay = dt1.Substring(11, 2);
			string dt3 = myYear + myMonth + myDay;

			string myYear1, myMonth1, myDay1;
			myYear1 = dt2.Substring(6, 4);
			myMonth1 = dt2.Substring(3, 2);
			myDay1 = dt2.Substring(0, 2);
			string dt4 = myYear1 + myMonth1 + myDay1;
			int i = dt4.CompareTo(dt3);
			return (i);
		}
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("IE_Marked_To_Vendor.aspx?VEND_CD=" + ddlVender.SelectedItem.Value);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("IE_Marked_To_Vendor.aspx");
		}

		private void DgIEV1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				if (e.Item.Cells[3].Text == "-")
				{
					e.Item.Cells[5].Visible = true;
				}
				else
				{
					e.Item.Cells[5].Visible = false;
				}
			}
		}
	}
}