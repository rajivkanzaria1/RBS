using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.IE_IC_Photo_Enclosed
{
	public partial class IE_IC_Photo_Enclosed : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSearch.Attributes.Add("OnClick", "JavaScript:validate();");
			if (Convert.ToString(Request.Params["CASE_NO"]) != null)
			{
				txtCaseNo.Text = Request.Params["CASE_NO"].ToString();
				txtRdt.Text = Request.Params["CALL_RECV_DT"].ToString();
				txtCSNO.Text = Request.Params["CALL_SNO"].ToString();
				fillgrid();
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
		void fillgrid()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			try
			{
				string str1 = "select T49.CASE_NO,to_char(T49.CALL_RECV_DT,'dd/mm/yyyy')CALL_DT,T49.CALL_SNO,T49.BK_NO,T49.SET_NO,T09.IE_NAME,'IC_PHOTOS/'||FILE_1 FILE_1,'IC_PHOTOS/'||FILE_2 FILE_2,'IC_PHOTOS/'||FILE_3 FILE_3,'IC_PHOTOS/'||FILE_4 FILE_4,'IC_PHOTOS/'||FILE_5 FILE_5,NVL2(FILE_6,'IC_PHOTOS/'||FILE_6,'') FILE_6,NVL2(FILE_7,'IC_PHOTOS/'||FILE_7,'') FILE_7,NVL2(FILE_8,'IC_PHOTOS/'||FILE_8,'') FILE_8,NVL2(FILE_9,'IC_PHOTOS/'||FILE_9,'') FILE_9,NVL2(FILE_10,'IC_PHOTOS/'||FILE_10,'') FILE_10 from T49_IC_PHOTO_ENCLOSED T49, T17_CALL_REGISTER T17, T09_IE T09 where T49.CASE_NO=T17.CASE_NO and T49.CALL_RECV_DT=T17.CALL_RECV_DT and T49.CALL_SNO=T17.CALL_SNO and T17.IE_CD=T09.IE_CD and T17.REGION_CODE='" + Session["Region"].ToString() + "' ";

				if (txtCaseNo.Text.Trim() != "")
				{
					str1 = str1 + " and T49.CASE_NO='" + txtCaseNo.Text.Trim() + "'";
				}
				if (txtRdt.Text.Trim() != "")
				{
					str1 = str1 + " and T49.CALL_RECV_DT=to_Date('" + txtRdt.Text.Trim() + "','dd/mm/yyyy')";
				}
				if (txtCSNO.Text.Trim() != "")
				{
					str1 = str1 + " and T49.CALL_SNO=" + txtCSNO.Text.Trim();
				}
				if (txtBKNo.Text.Trim() != "")
				{
					str1 = str1 + " and T49.BK_NO='" + txtBKNo.Text.Trim() + "'";
				}
				if (txtSetNo.Text.Trim() != "")
				{
					str1 = str1 + " and T49.SET_NO='" + txtSetNo.Text.Trim() + "'";
				}
				if (Session["Uname"].ToString() == "")
				{
					str1 = str1 + " and T17.IE_CD=" + Session["IE_CD"];
				}
				string str2 = str1 + " ORDER BY T09.IE_NAME,T49.CALL_RECV_DT,BK_NO,SET_NO";

				OracleDataAdapter da1 = new OracleDataAdapter(str2, conn1);
				DataSet dsP1 = new DataSet();
				OracleCommand myOracleCommand1 = new OracleCommand(str2, conn1);
				conn1.Open();
				da1.SelectCommand = myOracleCommand1;
				da1.Fill(dsP1, "Table");
				//OracleDataAdapter da1 = new OracleDataAdapter(str1, conn1); 
				if (dsP1.Tables[0].Rows.Count == 0)
				{
					DgPhotos.Visible = false;
					//repdiv.Visible=false;
					//Label6.Visible =true;
					//						throw new System.Exception("No PurchaseOrder found. !!! ");
					//					lblError.Visible=true;
					DgPhotos.Visible = false;
					DisplayAlert("No Record Found!!!");
				}
				else
				{
					DgPhotos.DataSource = dsP1;
					DgPhotos.DataBind();
					DgPhotos.Visible = true;
					//					lblError.Visible=false;
					//repdiv.Visible=true;
					//Label6.Visible =false;
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
		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			fillgrid();
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			if (Session["Uname"].ToString() != "")
			{
				Response.Redirect("MainForm.aspx");
			}
			else if (Session["IE_NAME"].ToString() != "")
			{
				Response.Redirect("IE_Menu.aspx");
			}
		}
	}
}