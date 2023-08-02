using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Consignee_Search_Form
{
	public partial class Consignee_Search_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		DataSet dsP = new DataSet();
		string Ccode;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnMod.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelete.Attributes.Add("OnClick", "JavaScript:validate();");
			btnShow.Attributes.Add("OnClick", "JavaScript:validate1();");
			//btnShow.Attributes.Add("OnClick", "JavaScript:validate();"); 
			if (!(IsPostBack))
			{
				if (Convert.ToString(Request.QueryString["CONSIGNEE_CD"]) == "")
				{
					Ccode = "";
				}
				else
				{
					Ccode = Convert.ToString(Request.QueryString["CONSIGNEE_CD"]);
					txtConCD.Text = Ccode;
				}
			}
			Label4.Visible = false;
			if (Convert.ToString(Session["Role"]) != "Administrator" || Convert.ToString(Session["Region"]) != "N")
			{
				btnAdd.Enabled = false;
				btnMod.Enabled = false;
				btnDelete.Enabled = false;
				grdCON.Columns[0].Visible = false;
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

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(("Consignee_Form.aspx"));
		}

		protected void btnMod_Click(object sender, System.EventArgs e)
		{
			int check = match();
			if (check == 1)
			{
				string code = txtConCD.Text.Trim();
				Response.Redirect("Consignee_Form.aspx?Action=M&CONSIGNEE_CD=" + code);
			}
			else
			{
				DisplayAlert("InValid Consignee CD!!!");
			}
		}

		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			int check = match();
			if (check == 1)
			{
				string code = txtConCD.Text.Trim();
				Response.Redirect(("Consignee_Form.aspx?Action=D&CONSIGNEE_CD=" + code));
			}
			else
			{
				DisplayAlert("InValid Consignee CD!!!");
			}

		}
		public int match()
		{
			OracleCommand cmd = new OracleCommand("select count(CONSIGNEE_CD) from T06_CONSIGNEE where CONSIGNEE_CD=" + txtConCD.Text.Trim(), conn1);
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
				string str1 = "select V.CONSIGNEE_CD,nvl2(trim(V.CONSIGNEE_DEPT),trim(V.CONSIGNEE_DESIG)||'/'||trim(V.CONSIGNEE_DEPT),trim(V.CONSIGNEE_DESIG)) CONSIGNEE_NAME ,nvl2(trim(D.RLY_DESIG_DESC),trim(D.RLY_DESIG_DESC)||'/'||trim(V.CONSIGNEE_DEPT),trim(V.CONSIGNEE_DEPT))DESIG_DESC, V.CONSIGNEE_FIRM, NVL2(trim(CONSIGNEE_ADD2),trim(CONSIGNEE_ADD1)||'/'||trim(CONSIGNEE_ADD2),trim(CONSIGNEE_ADD1))CONSIGNEE_ADD1, NVL2(C.LOCATION,C.LOCATION||' : '||C.CITY,C.CITY) CONSIGNEE_CITY, V.GSTIN_NO from T06_CONSIGNEE V,T03_CITY C, T90_RLY_DESIGNATION D where V.CONSIGNEE_CITY=C.CITY_CD and V.CONSIGNEE_DESIG=D.RLY_DESIG_CD(+)";
				if (txtConCD.Text.Trim() != "")
				{
					str1 = str1 + " and CONSIGNEE_CD='" + txtConCD.Text.Trim() + "'";
				}
				if (txtConName.Text.Trim() != "")
				{
					str1 = str1 + " and upper(CONSIGNEE_DESIG) LIKE upper('%" + txtConName.Text.Trim() + "%')";
				}
				if (txtCFirm.Text.Trim() != "")
				{

					str1 = str1 + " and upper(CONSIGNEE_FIRM) LIKE upper('" + txtCFirm.Text.Trim() + "%')";
				}
				if (txtCity.Text.Trim() != "")
				{

					str1 = str1 + " and upper(C.CITY) LIKE upper('" + txtCity.Text.Trim() + "%')";
				}
				if (txtSAPCustCD.Text.Trim() != "")
				{

					str1 = str1 + " and SAP_CUST_CD_CON='" + txtSAPCustCD.Text.Trim() + "'";
				}

				if (txtGSTIN_NO.Text.Trim() != "")
				{

					str1 = str1 + " and UPPER(GSTIN_NO)=UPPER('" + txtGSTIN_NO.Text.Trim() + "')";
				}

				str1 = str1 + " Order by (trim(V.CONSIGNEE_DESIG)||'/'||trim(V.CONSIGNEE_DEPT)) ,V.CONSIGNEE_FIRM, NVL2(C.LOCATION,C.LOCATION||' : '||C.CITY,C.CITY)";

				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdCON.Visible = false;
					Label4.Visible = true;

				}
				else
				{
					grdCON.DataSource = dsP;
					grdCON.DataBind();
					grdCON.Visible = true;
					Label4.Visible = false;
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





	}
}