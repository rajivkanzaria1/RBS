using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Ongoing_Contracts_Edit
{
	public partial class Ongoing_Contracts_Edit : System.Web.UI.Page
	{
		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if (Convert.ToString(Request.Params["CONTRACT_CD"]) == "" || Convert.ToString(Request.Params["CONTRACT_CD"]) == null)
			{
				txtContractCD.Text = "";
			}
			else
			{
				txtContractCD.Text = Request.Params["CONTRACT_CD"].ToString();
			}

		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
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

		protected void btnShow_Click(object sender, System.EventArgs e)
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			DataSet dsP = new DataSet();
			try
			{
				string str1 = "select CLIENT_NAME,CLIENT_TYPE,CONTRACT_CD from ONGOING_NONRLY_CONTRACTS WHERE instr(upper(CLIENT_NAME),upper('" + txtBPOName.Text.Trim() + "'))>0 order by CLIENT_TYPE,CLIENT_NAME";
				//				
				//				if(txtBPOCD.Text.Trim()!="")
				//				{
				//					str1 = str1 + " AND BPO_CD = '"+txtBPOCD.Text.Trim()+"'";
				//				}
				//				if(txtBPOName.Text.Trim()!="")
				//				{
				//					str1 = str1 + " AND upper(BPO_NAME) Like upper('"+txtBPOName.Text.Trim()+"%')"; 
				//				}
				//				if(txtBPORailways.Text.Trim()!="")
				//				{
				//					str1 = str1 + " AND upper(BPO_RLY) Like upper('"+txtBPORailways.Text.Trim()+"')";
				//				}
				//				if(txtCity.Text.Trim()!="")
				//				{
				//				
				//					str1 = str1 + " and upper(C.CITY) LIKE upper('"+txtCity.Text.Trim()+"%')"; 
				//				}
				//				str1=str1 + " ORDER BY B.BPO_NAME, B.BPO_RLY, (B.BPO_ADD||','||NVL2(C.LOCATION,C.LOCATION||' : '||C.CITY,C.CITY))";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn);
				conn.Open();
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

				conn.Close();
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
				conn.Close();
			}
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Ongoing_Contract_Form.aspx");
		}

		protected void btnMod_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Ongoing_Contract_Form.aspx?CONTRACT_CD=" + txtContractCD.Text.Trim());
		}
	}
}