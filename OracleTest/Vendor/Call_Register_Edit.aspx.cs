using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Vendor
{
    public partial class Call_Register_Edit : System.Web.UI.UserControl
    {
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		DataSet dsP = new DataSet();
		//	string CNO,DT;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnMod;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.HyperLink Hyperlink2;
		protected Tittle.Controls.CustomDataGrid grdCNO;
		protected System.Web.UI.WebControls.TextBox txtDtOfReciept;
		protected System.Web.UI.WebControls.TextBox txtCaseNo;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtPONO;
		protected System.Web.UI.WebControls.Button btnSearch1;
		string CNO, DT, CSNO;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtPODT;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.TextBox txtCSNO;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.TextBox txtVendName;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox txtCallLetNo;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label8;

		private void Page_Load(object sender, System.EventArgs e)
		{
			btnMod.Attributes.Add("OnClick", "JavaScript:validate();");
			btnSearch.Attributes.Add("OnClick", "JavaScript:validate1();");


			if (!(IsPostBack))
			{
				if (Convert.ToString(Request.Params["CASE_NO"]) == null || Convert.ToString(Request.Params["CALL_RECV_DT"]) == null)
				{
					CNO = "";
					DT = "";

				}
				else
				{
					CNO = Convert.ToString(Request.Params["CASE_NO"].Trim());
					DT = Convert.ToString(Request.Params["CALL_RECV_DT"].Trim());
					CSNO = Convert.ToString(Request.Params["CALL_SNO"].Trim());
					txtCaseNo.Text = CNO;
					txtDtOfReciept.Text = DT;
					txtCSNO.Text = CSNO;
				}

				//				if(Session["Role_CD"].ToString()=="1")
				//				{
				//					btnCallStatus.Visible=true;
				//				}
				//				else if(Session["Role_CD"].ToString()=="4")
				//				{
				//					btnAdd.Visible=false;
				//					btnCallStatus.Visible=false;
				//					btnMod.Text="View Call";
				//					btnDelete.Visible=false;
				//					btnCCancellation.Visible=false;
				//				}
				//				else
				//				{
				//					btnCallStatus.Visible=false;
				//				}
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
			this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
			this.btnSearch.Click += new System.EventHandler(this.txtSearch_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



		int show2(string CNO)
		{
			conn1.Open();
			OracleCommand cmd22 = new OracleCommand("Select NVL(to_char(max(EXT_DELV_DT),'dd/mm/yyyy'),'01-JAN-01') EXT_DELV_DT from T15_PO_DETAIL where CASE_NO='" + CNO + "'", conn1);
			OracleDataReader or2 = cmd22.ExecuteReader();
			string ext_delv_dt = "";
			while (or2.Read())
			{

				ext_delv_dt = or2["EXT_DELV_DT"].ToString();
			}
			conn1.Close();
			if (ext_delv_dt == "01-JAN-01")
			{
				return (2);
			}
			else
			{
				System.DateTime w_dt1 = new System.DateTime(Convert.ToInt32(ext_delv_dt.Substring(6, 4)), Convert.ToInt32(ext_delv_dt.Substring(3, 2)), Convert.ToInt32(ext_delv_dt.Substring(0, 2)));
				System.DateTime w_dt2 = new System.DateTime(Convert.ToInt32(txtDtOfReciept.Text.Substring(6, 4)), Convert.ToInt32(txtDtOfReciept.Text.Substring(3, 2)), Convert.ToInt32(txtDtOfReciept.Text.Substring(0, 2)));
				TimeSpan ts = w_dt1 - w_dt2;
				int differenceInDays = ts.Days;
				if (differenceInDays < 5)
				{
					return (0);
				}
				else
				{
					return (1);
				}
			}

		}

		private void btnMod_Click(object sender, System.EventArgs e)
		{
			OracleDataReader or1;
			conn1.Open();
			OracleCommand cmd = new OracleCommand("Select T05.VEND_CD,T05.VEND_INSP_STOPPED, T05.VEND_REMARKS from T13_PO_MASTER T13, T05_VENDOR T05 where T13.VEND_CD=T05.VEND_CD and CASE_NO='" + txtCaseNo.Text.Trim() + "'", conn1);
			or1 = cmd.ExecuteReader();

			string w_itemBlocked = "";
			string w_remarksVend = "";
			while (or1.Read())
			{
				w_itemBlocked = or1["VEND_INSP_STOPPED"].ToString();
				w_remarksVend = or1["VEND_REMARKS"].ToString();
			}
			conn1.Close();
			string check = match();
			if (check == "2")
			{
				string code = txtCaseNo.Text.Trim();
				string dt = txtDtOfReciept.Text.Trim();
				string csno = txtCSNO.Text.Trim();
				if (w_itemBlocked == "Y")
				{
					string msg = "Some Items of the Vendor have been blocked due to following reasons :\\n" + w_remarksVend + "\\nDo You Still Want to Register/Update This Call?";
					Response.Write("<script language=JavaScript> var d=confirm('" + msg + "'); if(d==false) location.href='Call_Register_Edit.aspx'; else location.href='Call_Details_Form.aspx?Case_No=" + code + "&DT_RECIEPT=" + dt + "&CALL_SNO=" + csno + "&cstatus=M'</script>");
				}
				else
				{
					//Response.Redirect("Call_Details_Form.aspx?Action=M&Case_No=" + code + "&DT_RECIEPT="+dt+"&CALL_SNO="+csno);
					Response.Redirect("Call_Details_Form.aspx?Case_No=" + code + "&DT_RECIEPT=" + dt + "&CALL_SNO=" + csno + "&cstatus=M");
				}
			}
			//			else
			//			{
			//				DisplayAlert("No Record Present for the Given Case No, Call Date and Call SNo!!! ");
			//			}
		}





		public string match()
		{
			//			OracleCommand cmd=new OracleCommand(,conn1);
			int vend = 0;
			int mfg = 0;
			string cstatus = "";
			string test = "";
			//			conn1.Open(); 
			//			test= Convert.ToString(cmd.ExecuteScalar());
			//			conn1.Close();

			OracleCommand myOracleCommand = new OracleCommand("select VEND_CD, MFG_CD,CALL_STATUS from T17_CALL_REGISTER T17, T13_PO_MASTER T13 where T13.CASE_NO=T17.CASE_NO and  T13.CASE_NO='" + txtCaseNo.Text.Trim() + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + txtCSNO.Text.Trim(), conn1);
			conn1.Open();
			OracleDataReader reader = myOracleCommand.ExecuteReader();
			while (reader.Read())
			{
				vend = Convert.ToInt32(reader["VEND_CD"].ToString());
				mfg = Convert.ToInt32(reader["MFG_CD"].ToString());
				cstatus = reader["CALL_STATUS"].ToString();
			}
			reader.Close();
			conn1.Close();

			if (vend == 0 && mfg == 0)
			{
				test = "0";
				DisplayAlert("No Record Present for the Given Case No, Call Date and Call SNo!!! ");
			}
			else if ((vend.ToString() == Session["VEND_CD"].ToString() || mfg.ToString() == Session["VEND_CD"].ToString()) && cstatus == "M")
			{
				test = "2";

			}
			else
			{
				test = "1";
				DisplayAlert("You are not Authorised to Update The Call For Other Vendors OR For Call Status Other than Pending.!!! ");
			}
			return test;

		}

		//		public string match1()
		//		{
		//			OracleCommand cmd=new OracleCommand("select REGION_CODE from T13_PO_MASTER where CASE_NO='"+txtCaseNo.Text.Trim()+"'",conn1);
		//			string test="";
		//			conn1.Open(); 
		//			test= Convert.ToString(cmd.ExecuteScalar());
		//			conn1.Close();
		//			if(test=="\0" || test =="")
		//			{
		//				test="0";
		//			}
		//			else if(test==Session["Region"].ToString())
		//			{
		//				test="2";
		//			}
		//			else
		//			{
		//				test="1";
		//			}
		//			return test;
		//		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		private void txtSearch_Click(object sender, System.EventArgs e)
		{
			//			string str1 = "select P.CASE_NO,TO_CHAR(C.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT,C.CALL_INSTALL_NO,C.CALL_SNO,decode(C.CALL_STATUS,'M','Pending','A','Accepted','R','Rejection','C','Cancelled'||decode(C.CALL_CANCEL_STATUS,'N',' (Non Chargeable)','C',' (Chargeable)',''),'U','Under Lab Testing','S','Still Under Inspection','G','Stage Inspection')CALL_STATUS,C.CALL_LETTER_NO,C.REMARKS,P.PO_NO,TO_CHAR(P.PO_DT,'dd/mm/yyyy') PO_DT,I.IE_SNAME,(V.VEND_NAME||'('||NVL2(T.LOCATION,T.LOCATION||' : '||T.CITY,T.CITY)||')')VENDOR from T17_CALL_REGISTER C, T13_PO_MASTER P,T09_IE I, T05_VENDOR V,T03_CITY T where P.CASE_NO=C.CASE_NO(+) and C.IE_CD=I.IE_CD(+) and P.VEND_CD=V.VEND_CD and V.VEND_CITY_CD=T.CITY_CD and P.REGION_CODE='"+Session["Region"].ToString()+"'"; 
			string str1 = "select P.CASE_NO,TO_CHAR(C.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT,C.CALL_INSTALL_NO,C.CALL_SNO,decode(S.CALL_STATUS_CD,'C',S.CALL_STATUS_DESC||decode(C.CALL_CANCEL_STATUS,'N',' (Non Chargeable)','C',' (Chargeable)'||'@'||C.CALL_CANCEL_CHARGES||'+ S.T.',''),S.CALL_STATUS_DESC)CALL_STATUS,C.CALL_LETTER_NO,C.REMARKS,P.PO_NO,TO_CHAR(P.PO_DT,'dd/mm/yyyy') PO_DT,I.IE_SNAME,(V.VEND_NAME||'('||NVL2(T.LOCATION,T.LOCATION||' : '||T.CITY,T.CITY)||')')VENDOR from T17_CALL_REGISTER C, T13_PO_MASTER P,T09_IE I, T05_VENDOR V,T03_CITY T,T21_CALL_STATUS_CODES S where P.CASE_NO=C.CASE_NO(+) and C.IE_CD=I.IE_CD(+) and P.VEND_CD=V.VEND_CD and V.VEND_CITY_CD=T.CITY_CD and C.CALL_STATUS=S.CALL_STATUS_CD(+) and (P.VEND_CD='" + Session["VEND_CD"].ToString() + "' OR C.MFG_CD='" + Session["VEND_CD"].ToString() + "') and CALL_STATUS='M'";
			if (txtCaseNo.Text.Trim() != "")
			{
				str1 = str1 + " and P.CASE_NO='" + txtCaseNo.Text.Trim() + "'";
			}
			if (txtDtOfReciept.Text.Trim() != "")
			{

				str1 = str1 + " and C.CALL_RECV_DT=to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy')";
			}

			if (txtPONO.Text.Trim() != "")
			{
				str1 = str1 + " and upper(P.PO_NO) LIKE upper('%" + txtPONO.Text.Trim() + "%')";
			}

			if (txtPODT.Text.Trim() != "")
			{
				str1 = str1 + " and PO_DT=to_date('" + txtPODT.Text.Trim() + "','dd/mm/yyyy')";
			}
			if (txtVendName.Text != "")
			{
				str1 = str1 + " and UPPER(TRIM(V.VEND_NAME)) like UPPER('" + txtVendName.Text.Trim() + "%')";
			}
			if (txtCallLetNo.Text != "")
			{
				str1 = str1 + " and UPPER(TRIM(C.CALL_LETTER_NO)) like UPPER('" + txtCallLetNo.Text.Trim() + "')";
			}
			if (txtDtOfReciept.Text.Trim() != "" && txtPONO.Text.Trim() == "" && txtPODT.Text.Trim() == "" && txtCaseNo.Text.Trim() == "")
			{
				str1 = str1 + " order by C.CALL_RECV_DT,C.CALL_SNO";
			}
			else
			{
				str1 = str1 + " order by P.CASE_NO,C.CALL_RECV_DT";
			}
			OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			if (dsP.Tables[0].Rows.Count == 0)
			{
				grdCNO.Visible = false;
				//Label4.Visible=true;
				DisplayAlert("Their is no Pending Call Present for given Vendor/Manufacturer Or CASE!!!");
			}
			else
			{
				grdCNO.DataSource = dsP;
				//int rr=Convert.ToInt32(dsP.Tables[0].Rows.Count)*30 + 50 ;
				//grdCNO.Height=rr;
				grdCNO.DataBind();
				grdCNO.Visible = true;
				Label4.Visible = false;
			}
		}

		private void btnSearch1_Click(object sender, System.EventArgs e)
		{
			string str1 = "select P.CASE_NO,TO_CHAR(C.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT,P.PO_NO,TO_CHAR(P.PO_DT,'dd/mm/yyyy') PO_DT from T17_CALL_REGISTER C, T13_PO_MASTER P where P.CASE_NO=C.CASE_NO(+) ";
			if (txtPONO.Text.Trim() != "")
			{
				str1 = str1 + " and upper(P.PO_NO) LIKE upper('%" + txtPONO.Text.Trim() + "%')";
			}

			if (txtPODT.Text.Trim() != "")
			{
				str1 = str1 + " and PO_DT=to_date('" + txtPODT.Text.Trim() + "','dd/mm/yyyy')";
			}


			str1 = str1 + " order by CALL_RECV_DT,P.CASE_NO";
			OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			if (dsP.Tables[0].Rows.Count == 0)
			{
				grdCNO.Visible = false;
				Label4.Visible = true;
			}
			else
			{
				grdCNO.DataSource = dsP;
				//int rr=Convert.ToInt32(dsP.Tables[0].Rows.Count)*30 + 50 ;
				//grdCNO.Height=rr;
				grdCNO.DataBind();
				grdCNO.Visible = true;
				Label4.Visible = false;
			}
		}









	}
}
