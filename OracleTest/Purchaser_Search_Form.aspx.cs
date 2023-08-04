using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Purchaser_Search_Form
{
	public partial class Purchaser_Search_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		DataSet dsP = new DataSet();
		string Ccode;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnMod.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelete.Attributes.Add("OnClick", "JavaScript:validate();");
			btnShow.Attributes.Add("OnClick", "JavaScript:validate1();");
			if (!(IsPostBack))
			{
				if (Convert.ToString(Request.QueryString["PURCHASER_CD"]) == "")
				{
					Ccode = "";
				}
				else
				{
					Ccode = Convert.ToString(Request.QueryString["PURCHASER_CD"]);
					txtConCD.Text = Ccode;
				}
			}
			Label4.Visible = false;

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
			Response.Redirect(("Purchaser_Form.aspx"));
		}

		protected void btnMod_Click(object sender, System.EventArgs e)
		{
			string code = txtConCD.Text;
			Response.Redirect("Purchaser_Form.aspx?Action=M&PURCHASER_CD=" + code);
		}

		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			string code = txtConCD.Text;
			Response.Redirect(("Purchaser_Form.aspx?Action=D&PURCHASER_CD=" + code));
		}

		protected void btnShow_Click(object sender, System.EventArgs e)
		{
			try
			{
				string str1 = "select V.PURCHASER_CD, V.PURCHASER_DESIG, V.PURCHASER_FIRM, NVL2(C.LOCATION,C.LOCATION||' : '||C.CITY,C.CITY) PURCHASER_CITY from T92_PURCHASER  V,T03_CITY C where V.PURCHASER_CITY=C.CITY_CD";
				if (txtConCD.Text != "")
				{
					str1 = str1 + " and PURCHASER_CD='" + txtConCD.Text + "'";
				}
				if (txtPDesig.Text != "")
				{
					str1 = str1 + " and upper(PURCHASER_DESIG) LIKE upper('%" + txtPDesig.Text + "%')";
				}
				if (txtPFirm.Text != "")
				{
					str1 = str1 + " and upper(PURCHASER_FIRM) LIKE upper('%" + txtPFirm.Text + "%')";
				}
				str1 = str1 + " Order by PURCHASER_CD";

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