using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.IE_Search_Form
{
	public partial class IE_Search_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		DataSet dsP = new DataSet();
		string Icode;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnMod.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelete.Attributes.Add("OnClick", "JavaScript:validate();");
			btnShow.Attributes.Add("OnClick", "JavaScript:validate1();");
			if (!(IsPostBack))
			{
				if (Convert.ToString(Request.QueryString["IE_CD"]) == "")
				{
					Icode = "";
				}
				else
				{
					Icode = Convert.ToString(Request.QueryString["IE_CD"]);
					txtIECD.Text = Icode;
				}

				DataSet dsP1 = new DataSet();
				string str2 = "select I.CO_CD,NVL2(D.R_DESIGNATION,I.CO_NAME ||'/'|| D.R_DESIGNATION,I.CO_NAME) CO_NAME from T08_IE_CONTROLL_OFFICER I, T07_RITES_DESIG D where I.CO_DESIG =D.R_DESIG_CD and CO_REGION='" + Session["Region"].ToString() + "' ORDER BY I.CO_NAME";
				OracleDataAdapter da1 = new OracleDataAdapter(str2, conn1);
				OracleCommand myOracleCommand1 = new OracleCommand(str2, conn1);
				ListItem lst1;
				conn1.Open();
				da1.SelectCommand = myOracleCommand1;
				da1.Fill(dsP1, "Table");
				lst1 = new ListItem();
				for (int j = 0; j <= dsP1.Tables[0].Rows.Count - 1; j++)
				{
					lst1 = new ListItem();
					lst1.Text = dsP1.Tables[0].Rows[j]["CO_NAME"].ToString();
					lst1.Value = dsP1.Tables[0].Rows[j]["CO_CD"].ToString();
					lstCOCD.Items.Add(lst1);
				}
				lstCOCD.Items.Insert(0, "");
				conn1.Close();
			}
			Label4.Visible = false;
			if (Convert.ToString(Session["Role"]) != "Administrator")
			{
				btnAdd.Enabled = false;
				btnMod.Enabled = false;
				btnDelete.Enabled = false;
				grdVend.Columns[0].Visible = false;
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
			Response.Redirect(("IE_Form.aspx"));
		}

		protected void btnMod_Click(object sender, System.EventArgs e)
		{
			char check = match();
			if (check.ToString() == "2")
			{
				string code = txtIECD.Text.Trim();
				Response.Redirect("IE_Form.aspx?Action=M&IE_CD=" + code);
			}
		}

		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			char check = match();
			if (check.ToString() == "2")
			{
				string code = txtIECD.Text.Trim();
				Response.Redirect(("IE_Form.aspx?Action=D&IE_CD=" + code));
			}

		}
		public char match()
		{
			OracleCommand cmd = new OracleCommand("select IE_REGION from T09_IE where IE_CD=" + txtIECD.Text.Trim(), conn1);
			char test;
			conn1.Open();
			test = Convert.ToChar(cmd.ExecuteScalar());
			conn1.Close();
			if (test.ToString() == "\0" || test.ToString() == null)
			{
				test = '0';
				DisplayAlert("InValid IE CD!!!");
			}
			else if (test.ToString() == Session["Region"].ToString())
			{
				test = '2';
			}
			else
			{
				test = '1';
				DisplayAlert("You Are Not Authorised to Update/Delete IE data of other Regions!!!");
			}
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
				//string str1 = "select V.IE_CD, V.IE_NAME,V.IE_SNAME,V.IE_EMP_NO,V.IE_SEAL_NO,NVL2(C.LOCATION,C.LOCATION||' : '||C.CITY,C.CITY) IE_CITY_CD,V.IE_REGION from T09_IE V,T03_CITY C where V.IE_CITY_CD=C.CITY_CD(+) and V.IE_REGION='" + Session["Region"].ToString() + "'";
				string str1 = "select V.IE_CD, V.IE_NAME,V.IE_SNAME,V.IE_EMP_NO,V.IE_SEAL_NO,NVL2(C.LOCATION,C.LOCATION||' : '||C.CITY,C.CITY) IE_CITY_CD,V.IE_REGION from T09_IE V,T03_CITY C where V.IE_CITY_CD=C.CITY_CD(+) ";

				if (txtIECD.Text.Trim() != "")
				{
					str1 = str1 + " and IE_CD = " + txtIECD.Text.Trim();
				}

				if (txtIELName.Text.Trim() != "")
				{
					str1 = str1 + " and upper(IE_NAME) LIKE upper('%" + txtIELName.Text.Trim() + "%')";
				}

				if (txtIESName.Text.Trim() != "")
				{
					str1 = str1 + " and upper(IE_SNAME) LIKE upper('" + txtIESName.Text.Trim() + "%')";
				}

				if (lstCOCD.SelectedValue != "")
				{
					str1 = str1 + " and IE_CO_CD=" + lstCOCD.SelectedValue;
				}

				str1 = str1 + " ORDER BY IE_NAME";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdVend.Visible = false;
					Label4.Visible = true;

				}
				else
				{
					grdVend.DataSource = dsP;
					grdVend.DataBind();
					grdVend.Visible = true;
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