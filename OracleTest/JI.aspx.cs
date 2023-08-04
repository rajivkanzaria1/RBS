using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.JI
{
	public partial class JI : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblIE;
		protected System.Web.UI.WebControls.Label lblRegion;
		protected System.Web.UI.WebControls.TextBox txtComplaintDt;
		protected System.Web.UI.WebControls.Label lblPoNo;
		protected System.Web.UI.WebControls.Label lblRly;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Label lblComplaintId;
		protected System.Web.UI.WebControls.Label lblConsignee;
		protected System.Web.UI.WebControls.Label lblIECd;
		protected System.Web.UI.WebControls.Label lblConsigneeCd;
		protected System.Web.UI.WebControls.Label lblCaseNo;
		protected System.Web.UI.WebControls.Label lblBkNo;
		protected System.Web.UI.WebControls.Label lblSetNo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.Label lblVendor;
		protected System.Web.UI.WebControls.Label lblVendorCd;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.TextBox txtDt1stRef;
		protected System.Web.UI.WebControls.Label txtMemoNo;
		protected System.Web.UI.WebControls.Label txtMemoDt;
		protected System.Web.UI.WebControls.Label txtItemDesc;
		protected System.Web.UI.WebControls.Label txtQtyPassed;
		protected System.Web.UI.WebControls.Label txtQtyRej;
		protected System.Web.UI.WebControls.Label txtValueRej;
		protected System.Web.UI.WebControls.Label txtRejReason;
		protected System.Web.UI.WebControls.Label txtStatus;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.TextBox txtJIDT;
		protected System.Web.UI.WebControls.TextBox txtJINO;
		OracleConnection Conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		private void Page_Load(object sender, System.EventArgs e)
		{
			//			btnSave.Attributes.Add("OnClick", "JavaScript:validate();"); 
			//btnDelete.Attributes.Add("OnClick", "JavaScript:validate();");
			if (!(IsPostBack))
			{
				if ((Convert.ToString(Request.Params["CASE_NO"]) != null) & (Convert.ToString(Request.Params["BK_NO"]) != null) & (Convert.ToString(Request.Params["SET_NO"]) != null))
				{
					lblCaseNo.Text = Convert.ToString(Request.Params["CASE_NO"].Trim());
					lblBkNo.Text = Convert.ToString(Request.Params["BK_NO"].Trim());
					lblSetNo.Text = Convert.ToString(Request.Params["SET_NO"].Trim());
					FindIE();
					//				
					string wRegion = Convert.ToString(Session["REGION"]);
					if (wRegion == "N") { lblRegion.Text = "Northern Region"; }
					else if (wRegion == "E") { lblRegion.Text = "Eastern Region"; }
					else if (wRegion == "W") { lblRegion.Text = "Western Region"; }
					else if (wRegion == "S") { lblRegion.Text = "Southern Region"; }
					else if (wRegion == "C") { lblRegion.Text = "Central Region"; }
					else { lblRegion.Text = ""; }
					try
					{
						Conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
						Conn.Open();
						OracleCommand cmd = new OracleCommand("select to_char(sysdate,'dd/mm/yyyy') from dual", Conn);
						txtComplaintDt.Text = Convert.ToString(cmd.ExecuteScalar());
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
						Conn.Close();
						Conn.Dispose();
					}
					rbs.SetFocus(txtMemoNo);
				}
				else if (Convert.ToString(Request.Params["COMPLAINT_ID"]) != null)
				{
					lblComplaintId.Text = Convert.ToString(Request.Params["COMPLAINT_ID"].Trim());
					getComplaintDetails();
				}
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
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		//		private void btnSave_Click(object sender, System.EventArgs e)
		//		{
		//			try
		//			{
		//				Conn= new System.Data.OracleClient.OracleConnection((ConfigurationSettings.AppSettings["ConnectionString"])) ;
		//				Conn.Open(); 
		//				OracleCommand MyCmd = new OracleCommand("select to_char(sysdate,'dd/mm/yyyy') from dual",Conn);
		//				string wDate=Convert.ToString(MyCmd.ExecuteScalar());
		//				string MySql="";
		//				//
		//				if (Convert.ToString(Request.Params["COMPLAINT_ID"])== null) 
		//				{
		//					MySql="Insert into T40_CONSIGNEE_COMPLAINTS(COMPLAINT_ID,COMPLAINT_DT,REJ_MEMO_NO,REJ_MEMO_DT,CASE_NO,"+
		//						"BK_NO,SET_NO,INSP_REGION,IE_INSP_REGION,COMP_RECV_REGION,CONSIGNEE_CD,VEND_CD,ITEM_DESC,"+
		//						"QTY_PASSED,QTY_REJECTED,REJECTION_VALUE,DT_1ST_REF,REJECTION_REASON,STATUS,USER_ID,DATETIME) "+		
		//						"values "+
		//						"(1,to_date('"+txtComplaintDt.Text+"','dd/mm/yyyy'),'"+txtMemoNo.Text+"',to_date('"+txtMemoDt.Text+"','dd/mm/yyyy'),'"+lblCaseNo.Text+
		//						"','"+lblBkNo.Text+"','"+lblSetNo.Text+"',substr('"+lblCaseNo.Text+"',1,1),"+lblIECd.Text+",'"+Session["Region"].ToString()+"',"+lblConsigneeCd.Text+","+lblVendorCd.Text+",'"+txtItemDesc.Text+
		//						"',"+txtQtyPassed.Text+","+txtQtyRej.Text+","+txtValueRej.Text+",to_date('"+txtDt1stRef.Text+"','dd/mm/yyyy'),'"+txtRejReason.Text+"','"+txtStatus.Text+"','"+Session["Uname"]+"',to_date('" +wDate+"','dd/mm/yyyy-HH:MI:SS'))"; 
		//				}
		//				else
		//				{
		//					MySql="Update T40_CONSIGNEE_COMPLAINTS "+
		//					 "Set REJ_MEMO_NO='"+txtMemoNo.Text+"',REJ_MEMO_DT=to_date('"+txtMemoDt.Text+"','dd/mm/yyyy'),ITEM_DESC='"+txtItemDesc.Text+"',"+
		//					 "QTY_PASSED="+txtQtyPassed.Text+",QTY_REJECTED="+txtQtyRej.Text+",REJECTION_VALUE="+txtValueRej.Text+","+
		//					 "DT_1ST_REF=to_date('"+txtDt1stRef.Text+"','dd/mm/yyyy'),REJECTION_REASON='"+txtRejReason.Text+"',"+
		//					 "STATUS='"+txtStatus.Text+"',USER_ID='"+Session["Uname"]+"',DATETIME=to_date('" +wDate+"','dd/mm/yyyy-HH:MI:SS') "+
		//					 "Where COMPLAINT_ID='"+lblComplaintId.Text+"'";
		//				}
		//				//
		//				OracleCommand cmd = new OracleCommand(MySql,Conn);
		//				cmd.ExecuteNonQuery();
		//				DisplayAlert("Data saved");
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
		//				Conn.Close(); 
		//				Conn.Dispose();
		//			} 
		//		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		private void FindIE()
		{
			lblIE.Text = "";
			lblPoNo.Text = "";
			lblRly.Text = "";
			lblConsignee.Text = "";
			lblIECd.Text = "";
			lblConsigneeCd.Text = "";
			if (lblCaseNo.Text.Trim() == "" || lblBkNo.Text.Trim() == "" || lblSetNo.Text.Trim() == "") { }
			else
			{
				//Populate PO NO,PO Date, Railway,IE Name and Consignee//
				string MySql = "Select t09.IE_CD, t09.IE_NAME,trim(t13.PO_NO)||' dated- '||to_char(t13.PO_DT,'dd/mm/yyyy') PO,t13.RLY_CD,t20.CONSIGNEE_CD,v06.CONSIGNEE,t13.VEND_CD,v05.VENDOR " +
							"From T09_IE t09,T13_PO_MASTER t13,T20_IC t20,V06_CONSIGNEE v06,V05_VENDOR v05 " +
							"Where t20.CASE_NO='" + lblCaseNo.Text + "' and t20.BK_NO='" + lblBkNo.Text + "' and t20.SET_NO='" + lblSetNo.Text + "' " +
							"and t20.IE_CD=t09.IE_CD and t13.CASE_NO=t20.CASE_NO and t13.VEND_CD=v05.VEND_CD and t20.CONSIGNEE_CD=v06.CONSIGNEE_CD";
				try
				{
					Conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
					OracleCommand cmd = new OracleCommand(MySql, Conn);
					Conn.Open();
					OracleDataReader MyReader = cmd.ExecuteReader();
					while (MyReader.Read())
					{
						lblIE.Text = MyReader["IE_NAME"].ToString();
						lblPoNo.Text = MyReader["PO"].ToString();
						lblRly.Text = MyReader["RLY_CD"].ToString();
						lblConsignee.Text = MyReader["CONSIGNEE"].ToString();
						lblVendor.Text = MyReader["VENDOR"].ToString();
						lblIECd.Text = MyReader["IE_CD"].ToString();
						lblConsigneeCd.Text = MyReader["CONSIGNEE_CD"].ToString();
						lblVendorCd.Text = MyReader["VEND_CD"].ToString();
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
					Conn.Close();
					Conn.Dispose();
				}
			}
		}
		private void getComplaintDetails()
		{
			try
			{
				Conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				Conn.Open();
				string MySql = "Select to_char(COMPLAINT_DT,'dd/mm/yyyy')COMPLAINT_DATE,REJ_MEMO_NO,to_char(REJ_MEMO_DT,'dd/mm/yyyy')REJ_MEMO_DATE," +
							 "CASE_NO,BK_NO,SET_NO,trim(PO_NO)||' dated- '||to_char(PO_DT,'dd/mm/yyyy') PO,RLY_CD,INSP_REGION_NAME," +
							 "IE_NAME_INSP_REGION,COMP_RECV_REGN_NAME,CONSIGNEE,VENDOR,ITEM_DESC,QTY_PASSED,QTY_REJECTED,REJECTION_VALUE," +
							 "to_char(DT_1ST_REF,'dd/mm/yyyy')DT_1ST_REF,REJECTION_REASON,STATUS,JI_REQUIRED " +
							 "From V40_CONSIGNEE_COMPLAINTS Where COMPLAINT_ID='" + lblComplaintId.Text + "'";
				OracleCommand cmd = new OracleCommand(MySql, Conn);
				OracleDataReader MyReader = cmd.ExecuteReader();
				while (MyReader.Read())
				{
					lblRegion.Text = MyReader["COMP_RECV_REGN_NAME"].ToString();
					txtComplaintDt.Text = MyReader["COMPLAINT_DATE"].ToString();
					txtComplaintDt.Enabled = false;
					lblCaseNo.Text = MyReader["CASE_NO"].ToString();
					lblBkNo.Text = MyReader["BK_NO"].ToString();
					lblSetNo.Text = MyReader["SET_NO"].ToString();
					lblIE.Text = MyReader["IE_NAME_INSP_REGION"].ToString();
					lblPoNo.Text = MyReader["PO"].ToString();
					lblRly.Text = MyReader["RLY_CD"].ToString();
					lblConsignee.Text = MyReader["CONSIGNEE"].ToString();
					lblVendor.Text = MyReader["VENDOR"].ToString();
					txtMemoNo.Text = MyReader["REJ_MEMO_NO"].ToString();
					txtMemoDt.Text = MyReader["REJ_MEMO_DATE"].ToString();
					txtItemDesc.Text = MyReader["ITEM_DESC"].ToString();
					txtQtyPassed.Text = MyReader["QTY_PASSED"].ToString();
					txtQtyRej.Text = MyReader["QTY_REJECTED"].ToString();
					txtValueRej.Text = MyReader["REJECTION_VALUE"].ToString();
					txtRejReason.Text = MyReader["REJECTION_REASON"].ToString();
					txtStatus.Text = MyReader["STATUS"].ToString();
					txtDt1stRef.Text = MyReader["DT_1ST_REF"].ToString();
					txtDt1stRef.Enabled = false;

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
				Conn.Close();
				Conn.Dispose();
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Complaint_Case_Detail_Search.aspx");
		}

		//		private void btnJIOutcome_Click(object sender, System.EventArgs e)
		//		{
		//			try
		//			{
		//				Conn= new System.Data.OracleClient.OracleConnection((ConfigurationSettings.AppSettings["ConnectionString"])) ;
		//				Conn.Open(); 
		//				OracleCommand MyCmd = new OracleCommand("select to_char(sysdate,'dd/mm/yyyy') from dual",Conn);
		//				string wDate=Convert.ToString(MyCmd.ExecuteScalar());
		//				string MySql="Update T40_CONSIGNEE_COMPLAINTS "+
		//						"Set JI_REQUIRED='"+lstJIRequired.SelectedValue+"',USER_ID='"+Session["Uname"]+"',DATETIME=to_date('" +wDate+"','dd/mm/yyyy-HH:MI:SS') "+
		//						"Where COMPLAINT_ID='"+lblComplaintId.Text+"'";
		//				//
		//				OracleCommand cmd = new OracleCommand(MySql,Conn);
		//				cmd.ExecuteNonQuery();
		//				DisplayAlert("Data saved");
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
		//				Conn.Close(); 
		//				Conn.Dispose();
		//			} 
		//		}


	}
}