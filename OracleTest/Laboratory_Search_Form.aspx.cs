using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Laboratory_Search_Form
{
	public partial class Laboratory_Search_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnMod.Attributes.Add("OnClick", "JavaScript:validate();");
			btnShow.Attributes.Add("OnClick", "JavaScript:validate1();");
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
			Response.Redirect(("Laboratory_Master_Form.aspx"));
		}
		int CheckLab(int code)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string str1 = "select LAB_ID from T65_LABORATORY_MASTER where LAB_ID=" + code;
				OracleCommand myOracleCommand1 = new OracleCommand(str1, conn1);
				conn1.Open();
				string st = Convert.ToString(myOracleCommand1.ExecuteScalar());
				conn1.Close();
				if (st == "")
				{
					return (0);
				}
				else
				{
					return (1);
				}

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				return (0);
				//Response.Redirect(("Error_Form.aspx?err=" + str1));
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

		protected void btnMod_Click(object sender, System.EventArgs e)
		{
			int code = Convert.ToInt32(txtLabID.Text.Trim());
			int i = CheckLab(code);
			if (i == 1)
			{
				Response.Redirect("Laboratory_Master_Form.aspx?Action=M&LAB_ID=" + code);
			}
			else
			{
				DisplayAlert("Invalid Lab ID.");
			}

		}

		protected void btnShow_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				DataSet dsP = new DataSet();
				string str1 = " Select LAB_ID,LAB_NAME,LAB_ADDRESS, T03.CITY from T65_LABORATORY_MASTER T65, T03_CITY T03 where T65.LAB_CITY=T03.CITY_CD ";



				if (txtLabID.Text.Trim() != "")
				{

					str1 = str1 + " and T65.LAB_ID=" + txtLabID.Text;
				}

				if (txtLabName.Text.Trim() != "")
				{
					str1 = str1 + " and upper(LAB_NAME) LIKE upper('" + txtLabName.Text.Trim() + "%')";
				}

				if (txtLabAdd.Text.Trim() != "")
				{
					str1 = str1 + " and (upper(LAB_ADDRESS) LIKE upper('%" + txtLabAdd.Text.Trim() + "%')) ";
				}
				if (txtLabCity.Text.Trim() != "")
				{
					str1 = str1 + " and upper(T03.CITY) LIKE upper('" + txtLabCity.Text.Trim() + "%') ";
				}
				str1 = str1 + " order by LAB_NAME";

				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdLab.Visible = false;
					DisplayAlert("No Lab Found!!!");
					//Label4.Visible=true;
				}
				else
				{
					grdLab.Visible = true;
					grdLab.DataSource = dsP;
					grdLab.DataBind();
					Label8.Visible = true;
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
	}
}