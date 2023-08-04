using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.BPO_List
{
	public partial class BPO_List : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		DataSet dsP = new DataSet();
		string BPOcode;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnMod.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelete.Attributes.Add("OnClick", "JavaScript:validate();");
			btnShow.Attributes.Add("OnClick", "JavaScript:validate1();");
			if (!(IsPostBack))
			{
				if (Convert.ToString(Request.QueryString["BPO_CD"]) == "")
				{
					BPOcode = "";
				}
				else
				{
					BPOcode = Convert.ToString(Request.QueryString["BPO_CD"]);
					txtBPOCD.Text = BPOcode;
				}
			}
			repdiv.Visible = false;
			if (Convert.ToString(Session["Role"]) != "Administrator" || Convert.ToString(Session["Region"]) != "N")
			{
				btnAdd.Enabled = false;
				btnMod.Enabled = false;
				btnDelete.Enabled = false;
				grdBPO.Columns[0].Visible = false;
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
			this.grdBPO.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grdBPO_PageIndexChanged);

		}
		#endregion

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(("Bill_Paying_Officer_Form.aspx"));
		}

		protected void btnMod_Click(object sender, System.EventArgs e)
		{
			int check = match();
			if (check == 1)
			{
				string code = txtBPOCD.Text.Trim();
				Response.Redirect("Bill_Paying_Officer_Form.aspx?Action=E&BPO_CD=" + code);
			}
			else
			{
				DisplayAlert("Invalid BPO CD!!!");
			}
		}

		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			int check = match();
			if (check == 1)
			{
				string code = txtBPOCD.Text.Trim();
				Response.Redirect(("Bill_Paying_Officer_Form.aspx?Action=D&BPO_CD=" + code));
			}
			else
			{
				DisplayAlert("Invalid BPO CD!!!");
			}

		}

		public int match()
		{
			OracleCommand cmd = new OracleCommand("select count(BPO_CD) from T12_BILL_PAYING_OFFICER where BPO_CD='" + txtBPOCD.Text.Trim() + "'", conn1);
			int test = 0;
			conn1.Open();
			test = Convert.ToInt32(cmd.ExecuteScalar());
			conn1.Close();
			return test;
		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		protected void btnShow_Click(object sender, System.EventArgs e)
		{
			try
			{
				string str1 = "select B.BPO_CD, B.BPO_NAME, B.BPO_RLY, (B.BPO_ADD||','||NVL2(C.LOCATION,C.LOCATION||' : '||C.CITY,C.CITY)) BPO_ADD, GSTIN_NO, A.AU||'-'||A.AUDESC AUDESC from T12_BILL_PAYING_OFFICER B, T03_CITY C, AU_CRIS A WHERE B.BPO_CITY_CD=C.CITY_CD(+) AND A.AU(+)=B.AU";

				if (txtBPOCD.Text.Trim() != "")
				{
					str1 = str1 + " AND BPO_CD = '" + txtBPOCD.Text.Trim() + "'";
				}
				if (txtBPOName.Text.Trim() != "")
				{
					str1 = str1 + " AND upper(BPO_NAME) Like upper('" + txtBPOName.Text.Trim() + "%')";
				}
				if (txtBPORailways.Text.Trim() != "")
				{
					str1 = str1 + " AND upper(BPO_RLY) Like upper('" + txtBPORailways.Text.Trim() + "')";
				}
				if (txtCity.Text.Trim() != "")
				{

					str1 = str1 + " and upper(C.CITY) LIKE upper('" + txtCity.Text.Trim() + "%')";
				}
				if (txtSAPCustCD.Text.Trim() != "")
				{

					str1 = str1 + " and SAP_CUST_CD_BPO='" + txtSAPCustCD.Text.Trim() + "'";
				}
				if (txtGSTIN_NO.Text.Trim() != "")
				{

					str1 = str1 + " and UPPER(GSTIN_NO)=UPPER('" + txtGSTIN_NO.Text.Trim() + "')";
				}
				str1 = str1 + " ORDER BY B.BPO_NAME, B.BPO_RLY, (B.BPO_ADD||','||NVL2(C.LOCATION,C.LOCATION||' : '||C.CITY,C.CITY))";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");

				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdBPO.Visible = false;
					Label4.Visible = true;

				}
				else
				{
					grdBPO.DataSource = dsP;
					grdBPO.DataBind();
					grdBPO.Visible = true;
					Label4.Visible = false;
					repdiv.Visible = true;
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

		private void grdBPO_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grdBPO.CurrentPageIndex = e.NewPageIndex;
			grdBPO.DataBind();
		}





	}
}