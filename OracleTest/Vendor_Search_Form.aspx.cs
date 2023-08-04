using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Vendor_Search_Form
{
	public partial class Vendor_Search_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		//DataSet dsP = new DataSet();
		int Vcode;
		protected System.Web.UI.WebControls.HyperLink Hyperlink1;
		protected Tittle.Controls.CustomDataGrid CustomDataGrid1;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnMod.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelete.Attributes.Add("OnClick", "JavaScript:validate();");
			btnShow.Attributes.Add("OnClick", "JavaScript:validate1();");
			if (!(IsPostBack))
			{

				if (Convert.ToString(Request.QueryString["VEND_CD"]) == "" || Convert.ToString(Request.QueryString["VEND_CD"]) == null)
				{
					Vcode = 0;
				}
				else
				{
					Vcode = Convert.ToInt32(Request.QueryString["VEND_CD"]);
					txtVendCD.Text = Convert.ToString(Vcode);
					txtVendName.Text = Convert.ToString(Request.QueryString["VEND_NAME"]);
				}
			}
			Label4.Visible = false;
			//repdiv.Visible=false;
			if (Convert.ToString(Session["Role"]) != "Administrator" || Convert.ToString(Session["Region"]) != "N")
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
			this.grdVend.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grdVend_PageIndexChanged);

		}
		#endregion

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(("Vendor_Form.aspx"));
		}

		protected void btnMod_Click(object sender, System.EventArgs e)
		{
			int code = Convert.ToInt32(txtVendCD.Text.Trim());
			int i = CheckVend(code);
			if (i == 1)
			{
				Response.Redirect("Vendor_Form.aspx?Action=M&VEND_CD=" + code);
			}
			else
			{
				DisplayAlert("Invalid Vendor Code.");
			}

		}

		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			int code = Convert.ToInt32(txtVendCD.Text.Trim());
			int i = CheckVend(code);
			if (i == 1)
			{
				Response.Redirect(("Vendor_Form.aspx?Action=D&VEND_CD=" + code));
			}
			else
			{
				DisplayAlert("Invalid Vendor Code.");
			}
		}

		protected DataTable GetDataTable()
		{
			string str1 = "select V.VEND_CD, V.VEND_NAME, NVL2(C.LOCATION,C.LOCATION||' : '||C.CITY,C.CITY) VEND_CITY_CD,NVL2(V.VEND_ADD2,V.VEND_ADD1||' / '||V.VEND_ADD2,V.VEND_ADD1)VEND_ADD, NVL2(V.VEND_CONTACT_TEL_2,V.VEND_CONTACT_TEL_1||', '||VEND_CONTACT_TEL_2,VEND_CONTACT_TEL_1) VEND_CONT_NO, VEND_EMAIL from T05_VENDOR V,T03_CITY C where V.VEND_CITY_CD=C.CITY_CD(+)";
			if (txtVendCD.Text.Trim() != "")
			{
				str1 = str1 + " and trim(VEND_CD) = " + txtVendCD.Text.Trim();
			}
			if (txtVendName.Text.Trim() != "")
			{
				str1 = str1 + " and upper(VEND_NAME) LIKE upper('" + txtVendName.Text.Trim() + "%')";
			}
			if (txtVendAdd.Text.Trim() != "")
			{
				str1 = str1 + " and (upper(VEND_ADD1) LIKE upper('%" + txtVendAdd.Text.Trim() + "%') or upper(VEND_ADD2) LIKE upper('%" + txtVendAdd.Text.Trim() + "%')) ";
			}
			if (txtVendCity.Text.Trim() != "")
			{
				str1 = str1 + " and upper(C.CITY) LIKE upper('" + txtVendCity.Text.Trim() + "%') ";
			}
			str1 = str1 + " order by VEND_NAME, VEND_CITY_CD";
			OracleDataAdapter sda = new OracleDataAdapter(str1, conn1);
			DataTable dt = new DataTable();
			sda.Fill(dt);
			return dt;
		}
		int CheckVend(int code)
		{
			try
			{
				string str1 = "select VEND_CD from T05_VENDOR where VEND_CD=" + code;
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

		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		//		void show()
		//		{
		//			string str1 = "select V.VEND_CD, V.VEND_NAME, NVL2(C.LOCATION,C.LOCATION||' : '||C.CITY,C.CITY) VEND_CITY_CD from T05_VENDOR V,T03_CITY C where V.VEND_CITY_CD=C.CITY_CD(+)"; 
		//			if(txtVendCD.Text!="")
		//			{
		//				str1 =str1 + " and trim(VEND_CD)='"+txtVendCD.Text+"'"; 
		//			}
		//			if(txtVendName.Text!="")
		//			{
		//				str1 = str1 + " and upper(VEND_NAME) LIKE upper('%"+txtVendName.Text+"%')"; 
		//			}
		//
		//			str1= str1 + " order by VEND_NAME";
		//			OracleDataAdapter da = new OracleDataAdapter(str1, conn1); 
		//			OracleCommand myOracleCommand = new OracleCommand(str1, conn1); 
		//			conn1.Open(); 
		//			da.SelectCommand = myOracleCommand; 
		//			da.Fill(dsP, "Table"); 
		//			if(dsP.Tables[0].Rows.Count ==0)
		//			{
		//				grdVend.Visible =false;
		//				//repdiv.Visible=false;
		//				Label4.Visible=true;
		//			}
		//			else
		//			{
		//				grdVend.DataSource = dsP; 
		//				int rr=Convert.ToInt32(dsP.Tables[0].Rows.Count)*30 + 50 ;
		//				grdVend.Height=rr;
		//				grdVend.DataBind();
		//              	grdVend.Visible =true;
		//				//repdiv.Visible=true;
		//				Label4.Visible=false;
		//			}
		//				
		//			conn1.Close(); 
		//		}
		protected void btnShow_Click(object sender, System.EventArgs e)
		{

			//ViewState["dt"] = GetDataTable();
			//DataTable dt=(DataTable) ViewState["dt"];
			DataTable dt = GetDataTable();
			if (dt.Rows.Count == 0)
			{
				grdVend.Visible = false;
				Label4.Visible = true;
			}
			else
			{
				//grdVend.DataSource = (DataTable) ViewState["dt"];
				grdVend.Visible = true;
				grdVend.DataSource = dt;
				grdVend.DataBind();
				Label4.Visible = false;
			}
			//			try 
			//			{ 
			//				show();
			//			} 
			//			catch (Exception ex) 
			//			{ 
			//				string str; 
			//				str = ex.Message; 
			//				string str1=str.Replace("\n","");
			//				Response.Redirect(("Error_Form.aspx?err=" + str1));
			//			}
			//			finally
			//			{
			//				conn1.Close(); 
			//			} 
		}

		private void grdVend_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grdVend.CurrentPageIndex = e.NewPageIndex;
			grdVend.DataSource = (DataTable)ViewState["dt"];
			grdVend.DataBind();

		}

		protected void grdVend_SelectedIndexChanged(object sender, System.EventArgs e)
		{

		}




		//		private void grdVend_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		//		{
		//			grdVend.CurrentPageIndex=e.NewPageIndex;
		//			grdVend.DataSource = (DataTable) ViewState["dt"];
		//			grdVend.DataBind();
		//			//grdVend.DataBind();
		//			//show();
		//			//DataSet dsP2 = new DataSet();
		//			//DataSet dsP2 =(DataSet)ViewState["dsP1"];
		//			//System.IO.StringReader sr = new System.IO.StringReader((string)(ViewState["dsCustomers"]));
		//			//dsCustomers1.ReadXml(sr);
		//			//grdVend.DataSource = dsP; 
		//			//grdVend.DataBind(); 
		//		
		//		}






	}
}